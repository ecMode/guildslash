using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Button strengthAdd;
    public Button dexterityAdd;
    public Button intelligenceAdd;
    public Button staminaAdd;
    public Text statsAvailable;
    public Text magicFind;
    public Text defense;
    public Text criticalStrikeChance;

    // Update is called once per frame
    void Update()
    {
        statsAvailable.text = "Stats Remaining: " + GameManager.instance.Player.Attributes;
        criticalStrikeChance.text = "Critical Strike Chance: " + (GameManager.instance.Player.CriticalStrikeChance).ToString("0.00%");

        if (GameManager.instance.Player.Attributes > 0)
        {
            strengthAdd.enabled = true;
            dexterityAdd.enabled = true;
            intelligenceAdd.enabled = true;
            staminaAdd.enabled = true;
        }
        else
        {
            strengthAdd.enabled = false;
            dexterityAdd.enabled = false;
            intelligenceAdd.enabled = false;
            staminaAdd.enabled = false;
        }

    }
}
