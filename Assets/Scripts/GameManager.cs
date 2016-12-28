using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Player Player { get; set; }
    public Enemy Monster { get; set; }
    public UnityEngine.UI.Text playerName;
    private double lastSecond = 0;
    public GameStates GameState { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //Assume we have some prefabbed character and monster for testing
        Player = new Player();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        playerName.text = Player.Name;
        // hp regen should be done server side probs
        double seconds = Math.Floor(Time.time);
        if (lastSecond < seconds && seconds % 3 == 0 && GameState == GameStates.OUTOFCOMBAT && Player.CurrentHP < Player.MaxHP)
        {
            Player.CurrentHP++;
            lastSecond = seconds;
        }

    }

    public enum GameStates {
        OUTOFCOMBAT,
        INCOMBAT
    }
}
