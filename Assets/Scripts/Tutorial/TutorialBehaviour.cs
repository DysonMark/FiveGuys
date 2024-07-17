using System;
using System.Collections;
using System.Collections.Generic;
using JW.FiveGuys.Teleportation;
using Kandooz.InteractionSystem.Interactions;
using UnityEngine;

namespace SAE.FiveGuys.Tutorial
{
    public class TutorialBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject head;

        public TeleportationController teleport;

        public bool isObjectHasBeenGrab = false;

        public Grabable knowingIfObjectIsSelected;

        public int i = 0;
        // Start is called before the first frame update
        void Start()
        {
            head = GameObject.Find("Head");
        }

        // Update is called once per frame
        void Update()
        {
            if (teleport.isPlayerTeleporting == true)
            {
                Debug.Log("Player has teleported");
            }
            ObjectHasBeenGrab();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "TutorialGrab")
            {
                i = 1;
                ObjectHasBeenGrab();
            }

        }

        public void ObjectHasBeenGrab()
        {
            Debug.Log("Object has been grabbed");
            if (i == 1)
            {
                isObjectHasBeenGrab = true;
            }
            else if (i == 0)
            {
                isObjectHasBeenGrab = false;
            }
        }
    }
}
