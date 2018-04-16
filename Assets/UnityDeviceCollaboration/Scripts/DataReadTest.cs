using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReadTest : MonoBehaviour {

    public SerialHandler serialHandler;
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
    }
}
