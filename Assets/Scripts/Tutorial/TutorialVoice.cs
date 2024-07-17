using System.Collections;
using System.Collections.Generic;
using JW.FiveGuys.Teleportation;
using Unity.VisualScripting;
using UnityEngine;

namespace SAE.FiveGuys.Tutorial
{
    public class TutorialVoice : MonoBehaviour
    {
        [SerializeField] private AudioSource successfulTeleportation;
        [SerializeField] private AudioSource stopStartSound;
        [SerializeField] private AudioSource endOfTutorial;
        public TutorialBehaviour checkGrabbableObject;
        public TeleportationController didHeTeleported;

        // Start is called before the first frame update
        void Start()
        {
            successfulTeleportation.Pause();
            endOfTutorial.Pause();
        }

        // Update is called once per frame
        void Update()
        {
            if (didHeTeleported.isPlayerTeleporting == true)
            {
                successfulTeleportation.UnPause();
                stopStartSound.Stop();
            }
            else if (didHeTeleported.isPlayerTeleporting == false)
            {
                successfulTeleportation.Pause();
            }

            if (checkGrabbableObject.isObjectHasBeenGrab == true)
            {
                endOfTutorial.UnPause();
            }
        }
    }
}
