using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


namespace Leonardo.RythmRadioPuzzle
{
    public class RythmRadioPuzzle : MonoBehaviour
    {
        // Button states.
        [SerializeField]  private bool blueButtonTapped, yellowButtonTapped, greenButtonTapped, redButtonTapped;
        
        // Audio source.
        [SerializeField] private AudioSource audioSource;
        
        // Audio sound clips for buttons
        [SerializeField] private AudioClip blueButtonSFX, greenButtonSFX, redButtonSFX, yellowButtonSFX;
        
        // Audio sound clips for states.
        [SerializeField] private AudioClip winSFX, wrongSFX;
        
        private bool isPlayingSFX;
        
        // Visual effects
        [SerializeField] private GameObject blueButtonBase, greenButtonBase, redButtonBase, yellowButtonBase;
        private Renderer blueButtonRend, greenButtonRend, redButtonRend, yellowButtonRend;
        [SerializeField] private Material inactiveMaterial, activeMaterial;
        
        //----------------------------------------------------------------------------------------------------------------
        public UnityEvent radioPuzzleCompletionEvent; // Is called when the puzzle is finished.
        private bool radioPuzzleFinished;
        [SerializeField] private bool isPaused;
        [SerializeField] private float reactivationTime = 1.0f;
            
        [SerializeField] private int buttonsTimesPressed = 0; // Counter of the times the buttons were pressed.
        //----------------------------------------------------------------------------------------------------------------
        
        private List<string> correctSequence = new List<string> {"Blue", "Yellow", "Green", "Red"}; // Correct sequence for the puzzle.
        private List<string> playerSequence = new List<string>(); // Player current sequence.
        
        private void Start()
        {
            blueButtonRend = blueButtonBase.GetComponent<Renderer>();
            greenButtonRend = greenButtonBase.GetComponent<Renderer>();
            redButtonRend = redButtonBase.GetComponent<Renderer>();
            yellowButtonRend = yellowButtonBase.GetComponent<Renderer>();

            isPaused = false;
            radioPuzzleFinished = false;
            isPlayingSFX = false;
            blueButtonTapped = yellowButtonTapped = greenButtonTapped = redButtonTapped = false;
        }
        
        private void RestartPuzzle()
        {
            if (!radioPuzzleFinished)
            {
                isPaused = true;
                playerSequence.Clear();
                blueButtonTapped = yellowButtonTapped = greenButtonTapped = redButtonTapped = false;
                blueButtonRend.material = greenButtonRend.material = redButtonRend.material = yellowButtonRend.material = inactiveMaterial;
                StartCoroutine(ReactivatePuzzle());
                
                // Play SFX
                if (!isPlayingSFX)
                {
                    isPlayingSFX = true;
                    audioSource.clip = wrongSFX;
                    audioSource.Play();
                    StartCoroutine(BoolPlayingDelay(audioSource.clip.length));
                }
            }
        }

        private IEnumerator ReactivatePuzzle()
        {
            yield return new WaitForSeconds(reactivationTime);
            isPaused = false;
        }
        
        private void PuzzleCompleted()
        {
            radioPuzzleCompletionEvent.Invoke();
            radioPuzzleFinished = true;
            
            // Play SFX
            audioSource.clip = winSFX;
            audioSource.Play();
        }

        // Changes the boolean "isPlaying" as false after the audio stops playing so it doesn't play a SFX
        // every frame the button is being pressed.
        private IEnumerator BoolPlayingDelay(float delayDurationSfx)
        {
            yield return new WaitForSeconds(delayDurationSfx);
            isPlayingSFX = false;
        } 
        
        


        #region Button Related Scripts
        public void BlueButtonPressed()
        {
            if (!blueButtonTapped & !radioPuzzleFinished & !isPaused)
            {
                // Play SFX.
                audioSource.clip = blueButtonSFX;
                audioSource.Play();
                
                // Change bool so this function only happens as a trigger.
                blueButtonTapped = true;
                
                // Add this button being pressed to the player list sequence.
                playerSequence.Add("Blue");
                
                // Change to shiny material.
                blueButtonRend.material = activeMaterial;

            }

        }

        public void YellowButtonPressed()
        {
            if (!yellowButtonTapped & !radioPuzzleFinished & !isPaused)
            {
                // Play SFX.
                audioSource.clip = yellowButtonSFX;
                audioSource.Play();

                // Change bool so this function only happens as a trigger.
                yellowButtonTapped = true;
                
                // Add this button being pressed to the player list sequence.
                playerSequence.Add("Yellow");
                
                // Change to shiny material.
                yellowButtonRend.material = activeMaterial;
            }

        }
    
        public void GreenButtonPressed()
        {
            if (!greenButtonTapped & !radioPuzzleFinished & !isPaused)
            {
                // Play SFX.
                audioSource.clip = greenButtonSFX;
                audioSource.Play();

                // Change bool so this function only happens as a trigger.
                greenButtonTapped = true;
                
                // Add this button being pressed to the player list sequence.
                playerSequence.Add("Green");
                
                // Change to shiny material.
                greenButtonRend.material = activeMaterial;
                
            }

        } 
    
        public void RedButtonPressed()
        {
            if (!redButtonTapped & !radioPuzzleFinished & !isPaused)
            {
                // Play SFX.
                audioSource.clip = redButtonSFX;
                audioSource.Play();

                // Change bool so this function only happens as a trigger.
                redButtonTapped = true;
                
                // Add this button being pressed to the player list sequence.
                playerSequence.Add("Red");
                
                // Change to shiny material.
                redButtonRend.material = activeMaterial;
            }
        }

        private void CheckPlayerInput()
        {
            if (playerSequence.Count == correctSequence.Count)
            {
                if (!radioPuzzleFinished && playerSequence.SequenceEqual(correctSequence))
                {
                    PuzzleCompleted();
                }
                else if (!radioPuzzleFinished)
                {
                    RestartPuzzle();
                    ReactivatePuzzle();
                }
            }
        }
        
        #endregion

        #region Debug Related Scripts

        private void Update()
        {
            CheckPlayerInput();
            NonVRDebugMethod();
        }

        // Debug Input keys when not using VR.

        private void NonVRDebugMethod()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Radio_Puzzle: You pressed the BLUE button.");
                BlueButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Radio_Puzzle: You pressed the YELLOW button.");
                YellowButtonPressed();  
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Radio_Puzzle: You pressed the GREEN button.");
                GreenButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Radio_Puzzle: You pressed the RED button.");
                RedButtonPressed();
            }
        }
        
        #endregion

    }
}