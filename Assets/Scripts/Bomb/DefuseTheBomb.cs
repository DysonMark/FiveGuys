using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{
    public class DefuseTheBomb : MonoBehaviour
    {
        private int whichWire;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void BlueWire()
        {
            Debug.Log("Blue wire has been cut!");
            whichWire = 1;
        }

        public void RedWire()
        {
            Debug.Log("Red wire has been cut!");
            whichWire = 2;
        }

        public void YellowWire()
        {
            Debug.Log("Yellow wire has been cut!");
            whichWire = 3;
        }

        public void GreenWire()
        {
            Debug.Log("Green wire has been cut!");
            whichWire = 4;
        }

    }
}