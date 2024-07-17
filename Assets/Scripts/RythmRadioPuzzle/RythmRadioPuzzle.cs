using System;
using UnityEngine;


namespace Leonardo.RythmRadioPuzzle
{
    public class RythmRadioPuzzle : MonoBehaviour
    {
        // Debug purposes.
        [SerializeField]  private bool blueButtonTapped, yellowButtonTapped, greenButtonTapped, redButtonTapped;
        
        // Audio sound effects.
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip wrongButtonSFX, blueButtonSFX, yellowButtonSFX, greenButtonSFX, redButtonSFX;
        
        [SerializeField] private GameObject winParticleFX;
        
        [SerializeField] private int buttonsTimesPressed = 0; // Counter of the times the buttons were pressed.
        
        private void Start()
        {
            blueButtonTapped = yellowButtonTapped = greenButtonTapped = redButtonTapped = false;
        }



        private void WrongButtonPressed()
        {
            buttonsTimesPressed = 0;
            blueButtonTapped = yellowButtonTapped = greenButtonTapped = redButtonTapped = false;
            // Play SFX
            //audioSource.clip = wrongButtonSFX;
            //audioSource.Play();
            Debug.Log("Wrong button pressed.");
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
            if (!blueButtonTapped)
            {
                blueButtonTapped = true;
                
                // If this was the first button to be pressed, go to the next step.
                if (buttonsTimesPressed == 0)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    //audioSource.clip = blueButtonSFX;
                    //audioSource.Play();
                }
                else WrongButtonPressed();
            }

        }

        public void YellowButtonPressed()
        {
            if (!yellowButtonTapped)
            {
                yellowButtonTapped = true;
                
                if (buttonsTimesPressed == 1)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    //audioSource.clip = yellowButtonSFX;
                    //audioSource.Play();
                }
                else WrongButtonPressed();

            }

        }
    
        public void GreenButtonPressed()
        {
            if (!greenButtonTapped)
            {
                greenButtonTapped = true;
                
                if (buttonsTimesPressed == 2)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    //audioSource.clip = greenButtonSFX;
                    //audioSource.Play();
                }
                else WrongButtonPressed();

            }

        } 
    
        public void RedButtonPressed()
        {
            if (!redButtonTapped)
            {
                redButtonTapped = true;
                if (buttonsTimesPressed == 3)
                {
                    buttonsTimesPressed++;
                
                    // Play SFX
                    //audioSource.clip = redButtonSFX;
                    //audioSource.Play();
                
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