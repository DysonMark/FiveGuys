using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{ 
    public class BombBehavior : MonoBehaviour
    {
        private GameObject bomb;

        public BombCountdown verifyBomb;

        public DefuseTheBomb colorBomb;
        // Start is called before the first frame update
        private void Start()
        {
            bomb = GameObject.Find("TimerBomb1");
        }

        private void ChangeBombColor()
        {
            var bombRenderer = bomb.GetComponent<Renderer>();
            if (colorBomb.bombHasExploded == true)
            {
                bombRenderer.material.SetColor("_BaseColor", Color.red);   
            }
        }

        private void TurnBombGreen()
        {
            if (verifyBomb.bombChecker == 1)
            { 
                var bombRenderer = bomb.GetComponent<Renderer>();
                bombRenderer.material.SetColor("_BaseColor", Color.green);
            }
        }
        // Update is called once per frame
        private void Update()
        {
            TurnBombGreen();
            ChangeBombColor();
        }
    }
}
