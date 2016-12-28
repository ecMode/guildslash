using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBasicInfo : MonoBehaviour
{

    public Text playerLevel;
    public Text playerName;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerName.text = GameManager.instance.Player.Name;
        playerLevel.text = "Level: " + GameManager.instance.Player.Level.ToString();
    }
}
