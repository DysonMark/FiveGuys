using System.Collections;
using System.Collections.Generic;
using SAE.FiveGuys.Bomb;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public DefuseTheBomb dead;

    // Update is called once per frame
    void Update()
    {
        GameIsOver();
    }

    public void GameIsOver()
    {
        if (dead.bombHasExploded == true)
        {
            SceneManager.LoadScene(2);
            // Load first scene
        }
    }
}
