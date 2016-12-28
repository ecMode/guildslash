using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text percentHealthDisplay;
    public Text playerHPDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerHPDisplay.text = "HP: " + GameManager.instance.Player.CurrentHP;
        int remainder = GameManager.instance.Player.CurrentHP * 100 / GameManager.instance.Player.MaxHP;
        healthSlider.value = remainder;
        percentHealthDisplay.text = remainder + "%";
    }
}
