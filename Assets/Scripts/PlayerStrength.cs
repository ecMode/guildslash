using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStrength : MonoBehaviour
{

    public Text playerStrengthDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerStrengthDisplay.text = "Strength: " + GameManager.instance.Player.Strength;
    }
}
