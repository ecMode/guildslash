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
        CombatManager.instance.Enemy = monsterController.SpawnMonster();
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
        print("dmg range: " + CombatManager.instance.Enemy.EquippedWeapon.MinDamage + "-" + CombatManager.instance.Enemy.EquippedWeapon.MaxDamage);
        print("dmg: " + CombatManager.instance.Enemy.EquippedWeapon.Damage);
		print("EE value: " + CombatManager.instance.Enemy.EquippedWeapon.ItemStatValues[CombatManager.instance.Enemy.EquippedWeapon.ItemStats.IndexOf(BaseItem.Stats.ENHANCED_EFFECT)]);
        print("level: " + CombatManager.instance.Enemy.Level);
        for (int i= 0; i < CombatManager.instance.Enemy.EquippedWeapon.ItemStats.Count; i++)
        {
            print(CombatManager.instance.Enemy.EquippedWeapon.ItemStats[i] + "=" + CombatManager.instance.Enemy.EquippedWeapon.ItemStatValues[i]);
        }
        print("mod: " + CombatManager.instance.Enemy.EquippedWeapon.Modifier);
    }
}
