using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Character Character { get; set; }
    public Enemy Monster { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //Assume we have some prefabbed character and monster for testing
        Character = new Character();

        DontDestroyOnLoad(gameObject);
    }


}
