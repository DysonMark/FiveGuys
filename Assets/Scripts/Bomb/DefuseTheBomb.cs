using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{
    public class DefuseTheBomb : MonoBehaviour
    {
        public List<int> whichWire = new List<int>();

        private bool bluePass = false;

        private bool redPass = false;

        private bool yellowPass = false;

        private bool greenPass = false;

        public bool bombHasBeenDefused = false;

        public bool bombHasExploded = false;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            DefuseOrNot();
        }

        public void BlueWire()
        {
            Debug.Log("Blue wire has been cut!");
            whichWire.Add(1);
            if (whichWire == null)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else if (whichWire[0] != 1)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else
            {
                Debug.Log("Blue in right position!");
                bluePass = true;
                bombHasExploded = true;
            }
        }

        public void RedWire()
        {
            Debug.Log("Red wire has been cut!");
            whichWire.Add(2);
            
            if (whichWire.Count < 2)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else
            {
                Debug.Log("Red in right position!");
                redPass = true;
            }
        }

        public void YellowWire()
        {
            Debug.Log("Yellow wire has been cut!");
            whichWire.Add(3);
            if (whichWire.Count < 3)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else if (whichWire[2] != 3)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else
            {
                Debug.Log("Yellow in right position!");
                yellowPass = true;
            }
        }

        public void GreenWire()
        {
            Debug.Log("Green wire has been cut!");
            whichWire.Add(4);
            if (whichWire.Count < 4)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else if (whichWire[3] != 4)
            {
                Debug.Log("Bomb Exploded");
                bombHasExploded = true;
            }
            else
            {
                Debug.Log("Green in right position!");
                greenPass = true;
            }
        }

        private void DefuseOrNot()
        {
            for(int i = 0; i < whichWire.Count; i++)
            {
                Debug.Log("My list: " + whichWire[i]);
            }

            if (bluePass == true && redPass == true && yellowPass == true && greenPass == true)
            {
                Debug.Log("Bomb defused");
                bombHasBeenDefused = true;
            }
        }

    }
}