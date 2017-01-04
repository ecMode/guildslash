using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController {

	// Use this for initialization
	public Enemy SpawnMonster () {
        Enemy monster = new Enemy(GameManager.instance.Player.Level);
        return monster;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
