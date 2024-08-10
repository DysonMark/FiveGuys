using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Leonardo.RythmRadioPuzzle.TurnRadioOn
{
    public class PlayRadio : MonoBehaviour
    {
        [SerializeField] private AudioSource radioAudioSource;
        [SerializeField] private AudioClip radioSFX;
        private bool isPlaying;
        
        private void Start()
        {
            isPlaying = false;
            radioAudioSource.clip = radioSFX;
        }
        
        public void TurnRadioOn()
        {
            if (!isPlaying)
            {
                radioAudioSource.Play();
                StartCoroutine(BoolPlayingDelay(radioAudioSource.clip.length));
            }
        }
        
        private IEnumerator BoolPlayingDelay(float delayDurationSfx)
        {
            yield return new WaitForSeconds(delayDurationSfx);
            isPlaying = false;
        }

        #region Debug Specific Code

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                TurnRadioOn();
            }
        }

        #endregion
        
    }
}
