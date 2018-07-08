using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDDataSender : MonoBehaviour {

    [SerializeField]
    string sendData;

    [SerializeField]
    SerialHandler serialHandler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetData(string data)
    {
        sendData = data;
    }

    public void Send()
    {
        //serialHandler.
    }

}
