using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIntelligence : MonoBehaviour
{

    public Text playerIntelligenceDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerIntelligenceDisplay.text = "Intelligence: " + GameManager.instance.Player.Intelligence;
    }
}
