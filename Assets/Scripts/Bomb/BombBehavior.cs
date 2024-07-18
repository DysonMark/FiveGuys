using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{ 
    public class BombBehavior : MonoBehaviour
    {
        private GameObject bomb;

        public BombCountdown verifyBomb;
        // Start is called before the first frame update
        void Start()
        {
            bomb = GameObject.Find("Bomb");
            Invoke("ChangeBombColor", 600);
        }

        private void ChangeBombColor()
        {
            Debug.Log("Im here");
            var bombRenderer = bomb.GetComponent<Renderer>();
            bombRenderer.material.SetColor("_BaseColor", Color.red);
            Debug.Log("Explosion");
        }

        private void TurnBombGreen()
        {
            if (verifyBomb.bombChecker == 1)
            { 
                var bombRenderer = bomb.GetComponent<Renderer>();
                bombRenderer.material.SetColor("_BaseColor", Color.green);
            }
        }

        private void TurnBombRed()
        {
            if (verifyBomb.bombChecker == 2)
            { 
                var bombRenderer = bomb.GetComponent<Renderer>();
                bombRenderer.material.SetColor("_BaseColor", Color.red);
            }
        }
        // Update is called once per frame
        void Update()
        {
            TurnBombGreen();
            TurnBombRed();
        }
    }
}
