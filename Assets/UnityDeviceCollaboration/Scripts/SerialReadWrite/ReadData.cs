using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadData : MonoBehaviour
{
    public SerialHandler serial;

    Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        // データを受け取った時に呼び出される関数の設定
        serial.OnDataReceived += DataReceived;
    }

    void Update()
    {

    }

    private void DataReceived( string data )
    {
        text.text = data;
    }

}
