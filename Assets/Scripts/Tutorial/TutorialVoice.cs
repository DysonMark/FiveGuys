using System.Collections;
using System.Collections.Generic;
using JW.FiveGuys.Teleportation;
using Kandooz.InteractionSystem.Interactions;
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
        public TutorialProgression checkActions;
        [SerializeField] private AudioSource flashlight;
        [SerializeField] private AudioSource voice;
        [SerializeField] private AudioSource buttonVoice;
        [SerializeField] private AudioSource teleportation;
        public VRButton checkButtonState;


        // Start is called before the first frame update
        void Start()
        {
            successfulTeleportation.Pause();
            endOfTutorial.Pause();
            flashlight.Pause();
            voice.Pause();
            buttonVoice.Pause();
            teleportation.Pause();
        }

        // Update is called once per frame
        void Update()
        {
            Actions();
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

        private void Actions()
        {
            if (checkActions.action == 1)
            {
                stopStartSound.Pause();
                flashlight.UnPause();
            }
            else
            {
                flashlight.Pause();
            }

            if (checkActions.action == 2)
            {
                voice.UnPause();
            }
            else
            {
                voice.Pause();
            }

            if (checkButtonState.isClicked == true)
            {
                buttonVoice.UnPause();
            }
            else
            {
                buttonVoice.Pause();
            }

            if (checkActions.action == 3)
            {
                teleportation.UnPause();
            }
            else
            {
                teleportation.Pause();
            }

    }
    }
}
