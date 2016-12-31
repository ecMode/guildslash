using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{

    public Text playerStaminaDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerStaminaDisplay.text = "Stamina: " + GameManager.instance.Player.Stamina;
    }
}
