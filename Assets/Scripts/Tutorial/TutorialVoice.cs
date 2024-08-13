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
        public TutorialBehaviour valueOfI;
        public int y = 0;


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
                stopStartSound.Pause();
            }
            else if (didHeTeleported.isPlayerTeleporting == false)
            {
                successfulTeleportation.Pause();
            }
            
            if (valueOfI.i == 1)
            {
                endOfTutorial.UnPause();
                y = 1;
            }
            else if (valueOfI.i == 0)
            {
                endOfTutorial.Pause();
            }
        }
    }
}
