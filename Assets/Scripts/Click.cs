using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public UnityEngine.UI.Text killChainDisplay;
    public UnityEngine.UI.Text monsterNameDisplay;
    public UnityEngine.UI.Text monsterDamageTakenDisplay;
    public int killChain = 0;
    private MonsterController monsterController = new MonsterController();
    private DamageTaken damageTaken = null;

    public void Awake()
    {
        print(2314);
        CombatManager.instance.Enemy = new Enemy(GameManager.instance.Player.Level);
        print(CombatManager.instance.Enemy.CurrentHP);
        printEnemyStuff();
        GameManager.instance.GameState = GameManager.GameStates.INCOMBAT;
    }

    public void Update()
    {
        monsterNameDisplay.text = CombatManager.instance.Enemy.Name;
        killChainDisplay.text = "Kill Chain: " + killChain;
        if (damageTaken == null)
        {
            monsterDamageTakenDisplay.text = "";
        }
        else
        {
            monsterDamageTakenDisplay.text = damageTaken == null ? "" : damageTaken.EnemyDamageTaken.ToString();
            if (damageTaken.PlayerCriticalStrike)
            {
                monsterDamageTakenDisplay.fontStyle = FontStyle.Bold;
                monsterDamageTakenDisplay.fontSize = 16;
                monsterDamageTakenDisplay.color = Color.red;
            }
            else
            {
                monsterDamageTakenDisplay.fontStyle = FontStyle.Normal;
                monsterDamageTakenDisplay.fontSize = 14;
                monsterDamageTakenDisplay.color = Color.black;
            }
        }
    }

    public void Clicked()
    {
        if (CombatManager.instance.Enemy.CurrentHP == 0)
        {
            CombatManager.instance.Enemy = monsterController.SpawnMonster();
            printEnemyStuff();
            killChain += 1;
        }
        damageTaken = CombatManager.instance.CalculateDamage();
    }

    private void printEnemyStuff()
    {
        if (CombatManager.instance.Enemy.EquippedWeapon == null)
            return;
        print("dmg range: " + CombatManager.instance.Enemy.EquippedWeapon.MinDamage + "-" + CombatManager.instance.Enemy.EquippedWeapon.MaxDamage);
        print("dmg: " + CombatManager.instance.Enemy.EquippedWeapon.Damage);
        print("level: " + CombatManager.instance.Enemy.Level);
        print("level Requirement: " + CombatManager.instance.Enemy.EquippedWeapon.LevelRequirement);
        for (int i= 0; i < CombatManager.instance.Enemy.EquippedWeapon.ItemStats.Count; i++)
        {
            print(CombatManager.instance.Enemy.EquippedWeapon.ItemStats[i] + "=" + CombatManager.instance.Enemy.EquippedWeapon.ItemStatValues[i]);
        }
        print("mod: " + CombatManager.instance.Enemy.EquippedWeapon.Modifier);
    }
}
