using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    // String(�V���A���Ŏ󂯎����������)�������Ƃ���f���Q�[�g�^�̒�`
    public delegate void SerialDataReceivedEventHandler( string message );
    // �f�[�^���󂯎�������ɌĂяo�����f���Q�[�g
    public event SerialDataReceivedEventHandler OnDataReceived;

    // �V���A���|�[�g(Windows)
    public string portName = "COM3";
    // �V���A���|�[�g(Mac)
    //public string portName = "/dev/tty.usbmodem1421";

    // �{�[���[�g
    public int baudRate    = 9600;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    // �󂯎�����f�[�^
    private string message_;
    // �V�����f�[�^���󂯎�������̃t���O
    private bool isNewMessageReceived_ = false;

    void Awake()
    {
        Open();
    }

    void Update()
    {
        // �V�����f�[�^���󂯎������f���Q�[�g����ă��\�b�h�����s
        if ( isNewMessageReceived_ ) {
            OnDataReceived( message_ );
        }
    }

    void OnDestroy()
    {
        Close();
    }

    // �|�[�g�J������
    private void Open()
    {
        serialPort_ = new SerialPort( portName, baudRate, Parity.None, 8, StopBits.One );
        serialPort_.ReadTimeout = 500;
        serialPort_.Open();

        isRunning_ = true;

        // �f�[�^�̓ǂݍ��݂͕ʃX���b�h�œ�����
        thread_ = new Thread( Read );
        thread_.Start();
    }

    // �{�[�g������
    private void Close()
    {
        isRunning_ = false;

        if ( thread_ != null && thread_.IsAlive ) {
            thread_.Join();
        }

        if ( serialPort_ != null && serialPort_.IsOpen ) {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    // �f�[�^��M����
    private void Read()
    {
        
        while ( isRunning_ && serialPort_ != null && serialPort_.IsOpen ) {
            // �f�[�^���󂯎���Ă�����l��ۑ�����
            try {
                if ( serialPort_.BytesToRead > 0 ) {
                    message_ = serialPort_.ReadLine();
                    isNewMessageReceived_ = true;
                }
            } catch ( System.Exception e ) {
                Debug.LogWarning( e.Message );
            }
        }
    }

    // �f�[�^���M����
    public void Write( string message )
    {
        try {
            serialPort_.Write( message );
        } catch ( System.Exception e ) {
            Debug.LogWarning( e.Message );
        }
    }
}