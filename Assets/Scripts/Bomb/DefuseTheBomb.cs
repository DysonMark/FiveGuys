using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SAE.FiveGuys.Bomb
{
    public class DefuseTheBomb : MonoBehaviour
    {
        public List<int> whichWire = new List<int>();

        public bool bluePass = false;

        public bool redPass = false;

        public bool yellowPass = false;

        public bool greenPass = false;

        public bool bombHasBeenDefused = false;

        public bool bombHasExploded;
        public BombCountdown timeIsUp;
        
        // Update is called once per frame
        void Update()
        {
            DefuseOrNot();

        }
        public void BlueWire()
        {
            whichWire.Add(1);
            if (whichWire == null)
            {
                bombHasExploded = true;
            }
            else if (whichWire[0] != 1)
            {
                bombHasExploded = true;
            }
            else
            {
                bluePass = true;
            }
        }
        public void RedWire()
        {
            whichWire.Add(2);
            if (whichWire.Count < 2)
            {
                bombHasExploded = true;
            }
            else
            {
                redPass = true;
            }
        }
        public void YellowWire()
        {
            whichWire.Add(3);
            if (whichWire.Count < 3)
            {
                bombHasExploded = true;
            }
            else if (whichWire[2] != 3)
            {
                bombHasExploded = true;
            }
            else
            {
                yellowPass = true;
            }
        }
        public void GreenWire()
        {
            whichWire.Add(4);
            if (whichWire.Count < 4)
            {
                bombHasExploded = true;
            }
            else if (whichWire[3] != 4)
            {
                bombHasExploded = true;
            }
            else
            {
                greenPass = true;
            }
        }
        
        private void DefuseOrNot()
        {
            if (bluePass == true && redPass == true && yellowPass == true && greenPass == true)
            {
                bombHasBeenDefused = true;
            }

            if (timeIsUp.holdCounting <= 0)
            {
                bombHasExploded = true;
            }
            
        }

    }
}