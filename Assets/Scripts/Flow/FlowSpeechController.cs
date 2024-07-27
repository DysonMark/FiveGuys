using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;
using Oculus.Voice;

namespace JW.FiveGuys.Flow
{
    public class FlowSpeechController : MonoBehaviour
    {
        [SerializeField] private KeyCode activateOn = KeyCode.Space;
        [SerializeField] private AppVoiceExperience voiceControll;

        // Start is called before the first frame update
        void Update()
        {
            if (Input.GetKeyUp(activateOn))
            {
                voiceControll.Activate();
            }
        }
    } 
}
