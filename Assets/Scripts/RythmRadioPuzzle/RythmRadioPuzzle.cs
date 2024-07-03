using System;
using Kandooz.InteractionSystem.Core;
using Kandooz.InteractionSystem.Interactions;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace Leonardo.RythmRadioPuzzle
{
    public class RythmRadioPuzzle : MonoBehaviour
    {
        [SerializeField] private bool blueButtonPressed = false;
        [SerializeField] private bool yellowButtonPressed = false;
        [SerializeField] private bool greenButtonPressed = false;
        [SerializeField] private bool redButtonPressed = false;

        private int buttonsTimesPressed = 0; // Counter of the times the buttons were pressed.
        
        
        
        private void Update()
        {
            
        }

        private void PressCheck()
        {
            if (buttonsTimesPressed == 0)
            {
                
            }
        }
        
        public void BlueButtonPressed()
        {
            buttonsTimesPressed++;
            blueButtonPressed = true; 

        }

        public void YellowButtonPressed()
        {
            buttonsTimesPressed++;
            yellowButtonPressed = true;
            
        }
    
        public void GreenButtonPressed()
        {
            buttonsTimesPressed++;
            greenButtonPressed = true;
            
        } 
    
        public void RedButtonPressed()
        {
            buttonsTimesPressed++;
            redButtonPressed = true;
            
        }
    }
}