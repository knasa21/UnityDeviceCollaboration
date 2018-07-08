using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeyHello : MonoBehaviour {

    InputField inputField;
	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SeyValue()
    {
        Debug.Log(inputField.text);
    }



    public void Hello()
    {
        Debug.Log("Hello");
    }
}
