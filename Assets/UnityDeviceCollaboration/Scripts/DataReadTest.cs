using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataReadTest : MonoBehaviour {

    public SerialHandler serialHandler;
    public Text readBox;
	// Use this for initialization
	void Start () {
        serialHandler.OnDataReceived += OnDataReceived;	
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    void OnDataReceived(string message)
    {
        Debug.Log(message);
        readBox.text = message;
    }
}
