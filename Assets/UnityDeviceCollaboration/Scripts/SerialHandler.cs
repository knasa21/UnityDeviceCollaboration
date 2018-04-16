using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    public string portName = "COM5";
    public int baudRate = 9600;

    private SerialPort serialPort;
    private Thread thread;
    private bool isRunning = false;

    private string message;
    private bool isNewMessageReceived = false;

    private void Awake()
    {
        Open();
    }

    private void Update()
    {
        if (isNewMessageReceived) {
            OnDataReceived(message);
        }
    }

    private void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
        serialPort.Open();

        isRunning = true;

        thread = new Thread(Read);
        thread.Start();
    }

    private void Close()
    {
        isRunning = false;

        if (thread != null && thread.IsAlive) {
            thread.Join();
        }

        if(serialPort != null && serialPort.IsOpen) {
            serialPort.Close();
            serialPort.Dispose();
        }
    }

    private void Read()
    {
        while (isRunning && serialPort != null && serialPort.IsOpen) {
            try {
                if (serialPort.BytesToRead > 0) {
                    message = serialPort.ReadLine();
                    isNewMessageReceived = true;
                }
            } catch(System.Exception e) {
                Debug.LogWarning(e.Message);
            }
        }
    }

    private void Write(string message)
    {
        try {
            serialPort.Write(message);
        } catch (System.Exception e){
            Debug.LogWarning(e.Message);
        }
    }
}
