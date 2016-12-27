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
        int playerDamageTaken = CalculatePlayerDamageTaken();
        if(playerDamageTaken >= GameManager.instance.Character.CurrentHP)
        {
            GameManager.instance.Character.CurrentHP = 0;
        }
        else
        {
            GameManager.instance.Character.CurrentHP -= playerDamageTaken;
        }

        int monsterDamageTaken = CalculateEnemyDamageTaken();
        if (monsterDamageTaken >= Monster.CurrentHP)
        {
            Monster.CurrentHP = 0;
        }
        else
        {
            Monster.CurrentHP -= monsterDamageTaken;
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
