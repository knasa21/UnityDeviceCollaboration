using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    bool clicked = false;
    public SerialHandler serial;
    public Text textbox;

    public void OnPointerDown( PointerEventData eventData )
    {
        Debug.Log( "Down" );
        clicked = true;
    }

    public void OnPointerUp( PointerEventData eventData )
    {
        Debug.Log( "Up" );
        clicked = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( clicked ) {
            Debug.Log( "clicked" );
        }
    }

    public void SendData()
    {
        serial.Write( textbox.text );
    }
}
