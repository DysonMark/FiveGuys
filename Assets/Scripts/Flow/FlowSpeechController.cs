using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;
using Oculus.Voice;
using System.ComponentModel;

namespace JW.FiveGuys.Flow
{
    public class FlowSpeechController : MonoBehaviour
    {
        [SerializeField] private KeyCode activateOn = KeyCode.Space;
        [SerializeField] private AppVoiceExperience voiceControll;
        [SerializeField][ReadOnly(true)] private bool isActive = false;


        // Start is called before the first frame update
        void Update()
        {
            if (Input.GetAxis("XRI_Right_PrimaryButton") <= 1)
            {
                isActive = false;
            }

            if (Input.GetKeyUp(activateOn) || Input.GetAxis("XRI_Right_PrimaryButton") >= 1)
            {
                if (!isActive)
                {
                    voiceControll.Activate();
                    isActive = true;
                }
            }
        }
    } 
}
