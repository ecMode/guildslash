using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Slider healthSlider;
    public Text percentHealthDisplay;
    public Text enemyHPDisplay;

    // Use this for initialization
    void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemyHPDisplay.text = "HP: " + CombatManager.instance.Enemy.CurrentHP;
        int remainder = CombatManager.instance.Enemy.CurrentHP * 100 / CombatManager.instance.Enemy.MaxHP;
        healthSlider.value = remainder;
        percentHealthDisplay.text = remainder + "%";
    }
}
