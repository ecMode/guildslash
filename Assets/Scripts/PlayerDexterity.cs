using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDexterity : MonoBehaviour
{

    public Text playerDexterityDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerDexterityDisplay.text = "Dexterity: " + GameManager.instance.Player.Dexterity;
    }
}
