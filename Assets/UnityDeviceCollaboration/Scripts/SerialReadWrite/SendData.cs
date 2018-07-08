using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendData : MonoBehaviour
{
    public SerialHandler serial;
    public Text sendText;

    void Start()
    {
    }

    void Update()
    {
    }

    // テキストの送信
    public void SendText()
    {
        // シリアル通信で送信
        serial.Write( sendText.text );
    }

}
