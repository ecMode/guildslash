using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEXP : MonoBehaviour
{

    public Slider expSlider;
    public Text percentEXPDisplay;
    public Text playerEXPTextDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerEXPTextDisplay.text = "EXP: " + GameManager.instance.Player.CurrentExperience +
            "/" + GameManager.instance.Player.MaxExperience;
        float remainder = (float)(GameManager.instance.Player.CurrentExperience * 100 / GameManager.instance.Player.MaxExperience);
        expSlider.value = remainder;
        percentEXPDisplay.text = remainder + "%";
    }
}
