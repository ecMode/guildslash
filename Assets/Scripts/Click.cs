using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public UnityEngine.UI.Text killChainDisplay;
    public UnityEngine.UI.Text playerHPDisplay;
    public UnityEngine.UI.Text playerEXPDisplay;
    public UnityEngine.UI.Text monsterHPDisplay;
    public UnityEngine.UI.Text monsterNameDisplay;
    public int killChain = 0;
    private static CombatManager combatManager = new CombatManager();
    private MonsterController monsterController = new MonsterController();

    public void Awake()
    {
        combatManager.Monster = monsterController.SpawnMonster();
        //TODO: rename monster to enemy
        print("button awake");
    }
    public void Update()
    {
        playerHPDisplay.text = "HP: " + GameManager.instance.Character.CurrentHP;
        playerEXPDisplay.text = "EXP: " + GameManager.instance.Character.CurrentExperience +
            "/" + GameManager.instance.Character.MaxExperience;
        monsterHPDisplay.text = "Enemy HP: " + combatManager.Monster.CurrentHP;
        monsterNameDisplay.text = combatManager.Monster.Name;
        killChainDisplay.text = "Kill Chain: " + killChain;
    }

    public void Clicked()
    {
        combatManager.CalculateDamage();

        if (combatManager.Monster.CurrentHP == 0)
        {
            combatManager.Monster = monsterController.SpawnMonster();
            killChain += 1;
        }
    }
}
