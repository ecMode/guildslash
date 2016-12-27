using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

//or combat manager
public class CombatManager : MonoBehaviour {
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

    public void CalculateDamage()
    {
        int monsterDamageTaken = CalculateEnemyDamageTaken();
        if (monsterDamageTaken >= Monster.CurrentHP)
        {
            // Enemy was killed
            Monster.CurrentHP = 0;
            GameManager.instance.Character.CurrentExperience += Monster.ExperienceToAward;

            // Player gained a level
            if (GameManager.instance.Character.CurrentExperience > GameManager.instance.Character.MaxExperience)
            {
                double diffExperience = GameManager.instance.Character.CurrentExperience - GameManager.instance.Character.MaxExperience;
                GameManager.instance.Character.Level += 1;
                GameManager.instance.Character.CurrentExperience = diffExperience;
            }
            return;
        }
        else
        {
            Monster.CurrentHP -= monsterDamageTaken;
        }

        int playerDamageTaken = CalculatePlayerDamageTaken();
        if(playerDamageTaken >= GameManager.instance.Character.CurrentHP)
        {
            //Player was killed
            GameManager.instance.Character.CurrentHP = 0;
            GameManager.instance.Character.CurrentExperience -= 3000;
        }
        else
        {
            GameManager.instance.Character.CurrentHP -= playerDamageTaken;
        }
    }

    private int CalculatePlayerDamageTaken()
    {
        int enemyDamage = Monster.DamagePotential.nextInt();
        return enemyDamage;
    }

    private int CalculateEnemyDamageTaken()
    {
        int playerDamage = GameManager.instance.Character.DamagePotential.nextInt();
        return playerDamage;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
