using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private Player player;
    public Player Player {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
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
        // hp regen should be done server side probs
		// alternative https://youtu.be/xrv7ubLSaws?t=1255
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
