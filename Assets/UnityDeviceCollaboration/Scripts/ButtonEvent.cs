using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    bool clicked = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        clicked = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(clicked) {
            Debug.Log("clicked");
        }
	}
}
