using System;
using UnityEngine;


namespace Leonardo.RythmRadioPuzzle
{
    public class RythmRadioPuzzle : MonoBehaviour
    {
        // Debug purposes.
        [SerializeField]  private bool blueButtonPressed, yellowButtonPressed, greenButtonPressed, redButtonPressed;
        
        // Audio sound effects.
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip wrongButtonSFX, blueButtonSFX, yellowButtonSFX, greenButtonSFX, redButtonSFX;
        
        [SerializeField] private GameObject winParticleFX;
        
        [SerializeField] private int buttonsTimesPressed = 0; // Counter of the times the buttons were pressed.

        private void Start()
        {
            blueButtonPressed = yellowButtonPressed = greenButtonPressed = redButtonPressed = false;
        }

        private void Update()
        {
            // Debug Input keys when not using VR.
            if (Input.GetKeyUp(KeyCode.A))
            {
                Debug.Log("You pressed the BLUE button.");
                BlueButtonPressed();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                Debug.Log("You pressed the YELLOW button.");
                YellowButtonPressed();  
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Debug.Log("You pressed the GREEN button.");
                GreenButtonPressed();
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                Debug.Log("You pressed the RED button.");
                RedButtonPressed();
            }
        }

        private void WrongButtonPressed()
        {
            if (buttonsTimesPressed > 3)
            {
                Debug.Log("You've already completed the puzzle");
                return;
            }
            else
            {
                buttonsTimesPressed = 0;
                blueButtonPressed = yellowButtonPressed = greenButtonPressed = redButtonPressed = false;
                // Play SFX
                //audioSource.clip = wrongButtonSFX;
                //audioSource.Play();
                Debug.Log("Wrong button pressed.");
            }
        }
        
        private void PuzzleCompleted()
        {
            //Instantiate(winParticleFX, transform);
            Debug.Log("PUZZLE COMPLETED.");
            
            // Play SFX
        }


        #region Button Related Scripts
        public void BlueButtonPressed()
        {
            // If this was the first button to be pressed, go to the next step.
            if (buttonsTimesPressed == 0)
            {
                buttonsTimesPressed++;
                blueButtonPressed = true; // For Debug purposes.
                
                // Play SFX
                //audioSource.clip = blueButtonSFX;
                //audioSource.Play();
            }
            else WrongButtonPressed();
        }

        public void YellowButtonPressed()
        {
            if (buttonsTimesPressed == 1)
            {
                buttonsTimesPressed++;
                yellowButtonPressed = true; // For Debug purposes.
                
                // Play SFX
                //audioSource.clip = yellowButtonSFX;
                //audioSource.Play();
            }
            else WrongButtonPressed();
        }
    
        public void GreenButtonPressed()
        {
            if (buttonsTimesPressed == 2)
            {
                buttonsTimesPressed++;
                greenButtonPressed = true; // For Debug purposes.
                
                // Play SFX
                //audioSource.clip = greenButtonSFX;
                //audioSource.Play();
            }
            else WrongButtonPressed();
        } 
    
        public void RedButtonPressed()
        {
            if (buttonsTimesPressed == 3)
            {
                buttonsTimesPressed++;
                redButtonPressed = true; // For Debug purposes.
                
                // Play SFX
                //audioSource.clip = redButtonSFX;
                //audioSource.Play();
                
                PuzzleCompleted();
            }
            else WrongButtonPressed();
        }
        
        #endregion

    }
}