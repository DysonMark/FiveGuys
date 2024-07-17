using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Leonardo.RythmRadioPuzzle
{
    public class RythmRadioPuzzle : MonoBehaviour
    {
        // Debug purposes.
        [SerializeField]  private bool blueButtonTapped, yellowButtonTapped, greenButtonTapped, redButtonTapped;
        
        // Audio sound effects.
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip blueButtonSFX, greenButtonSFX, redButtonSFX, yellowButtonSFX;

        [SerializeField] private AudioClip winSFX, wrongSFX;
        private bool isPlaying;
        
        [SerializeField] private GameObject winParticleFX;
        private bool puzzleFinished;
            
        [SerializeField] private int buttonsTimesPressed = 0; // Counter of the times the buttons were pressed.
        
        private void Start()
        {
            puzzleFinished = false;
            isPlaying = false;
            blueButtonTapped = yellowButtonTapped = greenButtonTapped = redButtonTapped = false;
        }
        
        private void WrongButtonPressed()
        {
            if (!puzzleFinished)
            {
                buttonsTimesPressed = 0;
                blueButtonTapped = yellowButtonTapped = greenButtonTapped = redButtonTapped = false;
            
                // Play SFX
                if (!isPlaying)
                {
                    isPlaying = true;
                    audioSource.clip = wrongSFX;
                    audioSource.Play();
                    Debug.Log("Wrong button pressed.");
                    StartCoroutine(BoolPlayingDelay(audioSource.clip.length));
                }
            }
        }

        private IEnumerator BoolPlayingDelay(float delayDurationSfx)
        {
            yield return new WaitForSeconds(delayDurationSfx);
            isPlaying = false;
        } 
        
        private void PuzzleCompleted()
        {
            //Instantiate(winParticleFX, transform);
            Debug.Log("PUZZLE COMPLETED.");
            puzzleFinished = true;
            
            // Play SFX
            audioSource.clip = winSFX;
            audioSource.Play();
        }


        #region Button Related Scripts
        public void BlueButtonPressed()
        {
            if (!blueButtonTapped & !puzzleFinished)
            {
                blueButtonTapped = true;
                
                // If this was the first button to be pressed, go to the next step.
                if (buttonsTimesPressed == 0)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    audioSource.clip = blueButtonSFX;
                    audioSource.Play();
                }
                else WrongButtonPressed();
            }

        }

        public void YellowButtonPressed()
        {
            if (!yellowButtonTapped & !puzzleFinished)
            {
                yellowButtonTapped = true;
                
                if (buttonsTimesPressed == 1)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    audioSource.clip = yellowButtonSFX;
                    audioSource.Play();
                }
                else WrongButtonPressed();

            }

        }
    
        public void GreenButtonPressed()
        {
            if (!greenButtonTapped & !puzzleFinished)
            {
                greenButtonTapped = true;
                
                if (buttonsTimesPressed == 2)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    audioSource.clip = greenButtonSFX;
                    audioSource.Play();
                }
                else WrongButtonPressed();

            }

        } 
    
        public void RedButtonPressed()
        {
            if (!redButtonTapped & !puzzleFinished)
            {
                redButtonTapped = true;
                if (buttonsTimesPressed == 3)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    audioSource.clip = redButtonSFX;
                    audioSource.Play();
                
                    PuzzleCompleted();
                }
                else WrongButtonPressed();

            }

        }
        
        #endregion

        #region Debug Related Scripts

        private void Update()
        {
            // Debug Input keys when not using VR.
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("You pressed the BLUE button.");
                BlueButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("You pressed the YELLOW button.");
                YellowButtonPressed();  
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("You pressed the GREEN button.");
                GreenButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("You pressed the RED button.");
                RedButtonPressed();
            }
        }

        #endregion

    }
}