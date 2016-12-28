using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{

    public Slider manaSlider;
    public Text percentManaDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int remainder = GameManager.instance.Player.CurrentMP * 100 / GameManager.instance.Player.MaxMP;
        manaSlider.value = remainder;
        percentManaDisplay.text = remainder + "%";
    }
}
