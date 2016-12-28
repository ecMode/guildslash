using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{

    public Text playerLevel;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerLevel.text = "Level: " + GameManager.instance.Player.Level.ToString();
    }
}
