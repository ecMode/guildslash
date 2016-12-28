using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        if (sceneName == "Home")
        {
            GameManager.instance.GameState = GameManager.GameStates.OUTOFCOMBAT;
        }
    }
}
