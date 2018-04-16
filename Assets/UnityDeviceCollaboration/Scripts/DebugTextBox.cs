using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTextBox : MonoBehaviour {

    public Text textBox;
    public InputField inputField;
    public int countNumber = 0;

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SayHelloDebug()
    {
        Debug.Log("Hello World!");
    }

    public void SayHelloTextBox()
    {
        textBox.text = "Hello World!";    
    }

    public void InputTextCopy()
    {
        textBox.text = inputField.text;
    }

    public void AddNum()
    {
        countNumber++;
        textBox.text = countNumber.ToString();
    }
}
