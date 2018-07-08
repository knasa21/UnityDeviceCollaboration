using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour {

    public SerialHandler serialHandler;
    string datas;
    Text text;
	// Use this for initialization
	void Start () {
	    if(serialHandler != null) {
            serialHandler.OnDataReceived += DataPrint;
        }
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void DataPrint(string message)
    {
        //datas += message + "\n";
        //text.text = message;
    }
}
