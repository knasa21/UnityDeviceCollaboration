using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

// �V���A���ʐM�p�n���h��
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

    // ���s�����ǂ����̃t���O
    private bool isRunning_ = false;

    // �󂯎�����f�[�^
    private string message_;
    // �V�����f�[�^���󂯎�������̃t���O
    private bool isNewMessageReceived_ = false;

    // �N��������
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

    // �I��������
    void OnDestroy()
    {
        Close();
    }

    // �|�[�g�J������
    private void Open()
    {
        // �|�[�g�̐ݒ�ƊJ��
        serialPort_ = new SerialPort( portName, baudRate, Parity.None, 8, StopBits.One );
        serialPort_.ReadTimeout = 500;
        serialPort_.Open();

        // ���s���t���O���I��
        isRunning_ = true;

        // �f�[�^�̓ǂݍ��݂͕ʃX���b�h�œ�����
        thread_ = new Thread( Read );
        thread_.Start();
    }

    // �{�[�g������
    private void Close()
    {
        isRunning_ = false;

        // �X���b�h���~�߂�
        if ( thread_ != null && thread_.IsAlive ) {
            thread_.Join();
        }

        // �|�[�g��
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