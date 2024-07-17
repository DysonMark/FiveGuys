using System.Collections;
using System.Collections.Generic;
using JW.FiveGuys.Teleportation;
using UnityEngine;

namespace SAE.FiveGuys.Tutorial
{
    public class TutorialBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject head;

        public TeleportationController teleport;

        public bool isObjectHasBeenGrab = false;
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
        }

        public void ObjectHasBeenGrab()
        {
            Debug.Log("Object has been grabbed");
            isObjectHasBeenGrab = true;
        }
    }
}
