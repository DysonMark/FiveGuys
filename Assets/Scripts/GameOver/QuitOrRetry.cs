using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SAE.FiveGuys.GameOver
{
    public class QuitOrRetry : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
            Debug.Log("Player has quit");
        }

        public void Retry()
        {
            Debug.Log("Player has retry");
            SceneManager.LoadScene(2);
        }

    }
}
