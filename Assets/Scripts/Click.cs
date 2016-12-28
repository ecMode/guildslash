using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public UnityEngine.UI.Text killChainDisplay;
    public UnityEngine.UI.Text playerEXPTextDisplay;
    public UnityEngine.UI.Text monsterHPDisplay;
    public UnityEngine.UI.Text monsterNameDisplay;
    public UnityEngine.UI.Text monsterDamageTakenDisplay;
    public int killChain = 0;
    private static CombatManager combatManager = new CombatManager();
    private MonsterController monsterController = new MonsterController();
    private DamageTaken damageTaken = null;

    public void Awake()
    {
        combatManager.Monster = monsterController.SpawnMonster();
        GameManager.instance.GameState = GameManager.GameStates.INCOMBAT;
    }

    public void Update()
    {
        playerEXPTextDisplay.text = "EXP: " + GameManager.instance.Player.CurrentExperience +
            "/" + GameManager.instance.Player.MaxExperience;
        monsterHPDisplay.text = "Enemy HP: " + combatManager.Monster.CurrentHP;
        monsterNameDisplay.text = combatManager.Monster.Name;
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
        damageTaken = combatManager.CalculateDamage();
        if (combatManager.Monster.CurrentHP == 0)
        {
            combatManager.Monster = monsterController.SpawnMonster();
            killChain += 1;
        }
    }
}
