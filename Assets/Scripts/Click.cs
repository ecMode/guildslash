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
        print(CombatManager.instance.Enemy.ExperienceToAward);
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
            killChain += 1;
        }
        damageTaken = CombatManager.instance.CalculateDamage();
    }
}
