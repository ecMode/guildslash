using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddStatOnClick : MonoBehaviour
{
    public void AddStat(int stat)
    {
        if (stat == 0)
        {
            GameManager.instance.Player.Strength++;
        }
        else if (stat == 1)
        {
            GameManager.instance.Player.Dexterity++;
        }
        else if (stat == 2)
        {
            GameManager.instance.Player.Intelligence++;
        }
        else if (stat == 3)
        {
            GameManager.instance.Player.Stamina++;
        }
        GameManager.instance.Player.Attributes--;
    }
}
