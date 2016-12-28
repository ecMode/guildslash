using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class DamageTaken
{
    public int PlayerDamageTaken { get; set; }
    public bool PlayerCriticalStrike { get; set; }
    public int EnemyDamageTaken { get; set; }
    public bool EnemyCriticalStrike { get; set; }

    public DamageTaken(int playerDamageTaken, bool playerCriticalStrike, 
        int enemyDamageTaken, bool enemyCriticalStrike)
    {
        PlayerDamageTaken = playerDamageTaken;
        PlayerCriticalStrike = playerCriticalStrike;
        EnemyDamageTaken = enemyDamageTaken;
        EnemyCriticalStrike = enemyCriticalStrike;
    }
}
public class CombatManager
{
    private static System.Random random = new System.Random();
    private Enemy monster;
    public Enemy Monster
    {
        get
        {
            return monster;
        }
        set
        {
            monster = value;
        }
    }

    // Use this for initialization
    void Awake ()
    {
    }

    public DamageTaken CalculateDamage()
    {
        DamageTaken damageTaken = CalculateEnemyDamageTaken();
        if (damageTaken.EnemyDamageTaken >= Monster.CurrentHP)
        {
            // Enemy was killed
            Monster.CurrentHP = 0;
            GameManager.instance.Player.CurrentExperience += Monster.ExperienceToAward;

            // Player gained a level
            if (GameManager.instance.Player.CurrentExperience > GameManager.instance.Player.MaxExperience)
            {
                double diffExperience = GameManager.instance.Player.CurrentExperience - GameManager.instance.Player.MaxExperience;
                GameManager.instance.Player.CurrentExperience = diffExperience;
                GameManager.instance.Player.LevelUp();
            }
            return damageTaken;
        }
        else
        {
            Monster.CurrentHP -= damageTaken.EnemyDamageTaken;
        }

        damageTaken = CalculatePlayerDamageTaken(damageTaken);
        if (damageTaken.PlayerDamageTaken >= GameManager.instance.Player.CurrentHP)
        {
            //Player was killed
            GameManager.instance.Player.CurrentHP = 0;
            GameManager.instance.Player.CurrentExperience -= 3000;
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
        bool isCriticalStrike = randomInt <= GameManager.instance.Player.Dexterity * .5;
        int unModifiedPlayerDamage = GameManager.instance.Player.DamagePotential.nextInt();
        int modifiedPlayerDamage = isCriticalStrike ? (int)Math.Floor(unModifiedPlayerDamage * 1.5) : unModifiedPlayerDamage;
        return new DamageTaken(0, isCriticalStrike, modifiedPlayerDamage, false);
    }

    private DamageTaken CalculatePlayerDamageTaken(DamageTaken damageTaken)
    {
        damageTaken.PlayerDamageTaken = Monster.DamagePotential.nextInt();
        return damageTaken;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
