using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueText: MonoBehaviour
{
    public SerialHandler serial;
    public float value;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Sliderの値をTextにセット
    public void SetValue( float v )
    {
        value = v;
        text.text = v.ToString();
    }

}
