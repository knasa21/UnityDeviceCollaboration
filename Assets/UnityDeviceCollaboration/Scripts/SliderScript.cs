﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

    [SerializeField]
    private Text sliderValueArea;

    [SerializeField]
    private Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        		
	}

    public void SliderValueChange()
    {
        sliderValueArea.text = slider.value.ToString("F3");
    }
}
