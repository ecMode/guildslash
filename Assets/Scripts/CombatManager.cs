using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance = null;
    private static System.Random random = new System.Random();
    private Enemy enemy;
    public Enemy Enemy
    {
        get
        {
            return enemy;
        }
        set
        {
            enemy = value;
        }
    }

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public DamageTaken CalculateDamage()
    {
        DamageTaken damageTaken = CalculateEnemyDamageTaken();
        if (damageTaken.EnemyDamageTaken >= Enemy.CurrentHP)
        {
            // Enemy was killed
            Enemy.CurrentHP = 0;
            GameManager.instance.Player.CurrentExperience += Enemy.ExperienceToAward;

            // Player gained a level
            if (GameManager.instance.Player.CurrentExperience >= GameManager.instance.Player.MaxExperience)
            {
                double diffExperience = GameManager.instance.Player.CurrentExperience - GameManager.instance.Player.MaxExperience;
                GameManager.instance.Player.CurrentExperience = diffExperience;
                GameManager.instance.Player.LevelUp();
            }
            // Player doesn't take damage
            return damageTaken;
        }
        else
        {
            Enemy.CurrentHP -= damageTaken.EnemyDamageTaken;
        }

        damageTaken = CalculatePlayerDamageTaken(damageTaken);
        if (damageTaken.PlayerDamageTaken >= GameManager.instance.Player.CurrentHP)
        {
            //Player was killed
            GameManager.instance.Player.CurrentHP = 0;
            GameManager.instance.Player.CurrentExperience -= Math.Round(GameManager.instance.Player.CurrentExperience * .1);
            SceneManager.LoadScene("Death");
        }
        else
        {
            GameManager.instance.Player.CurrentHP -= damageTaken.PlayerDamageTaken;
        }
        return damageTaken;
    }

    private DamageTaken CalculateEnemyDamageTaken()
    {
        int randomInt = random.Next(0, 100);
        bool isCriticalStrike = randomInt <= (GameManager.instance.Player.CriticalStrikeChance * 100);
        int unModifiedPlayerDamage = GameManager.instance.Player.CalculateDamage();
        int modifiedPlayerDamage = isCriticalStrike ? (int)Math.Floor(unModifiedPlayerDamage * 1.5) : unModifiedPlayerDamage;
        return new DamageTaken(0, isCriticalStrike, modifiedPlayerDamage, false);
    }

    private DamageTaken CalculatePlayerDamageTaken(DamageTaken damageTaken)
    {
		damageTaken.PlayerDamageTaken = Enemy.CalculateDamage();
        return damageTaken;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
