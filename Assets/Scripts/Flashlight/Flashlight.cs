using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.FiveGuys.LightMoth
{
    /// <summary>
    /// Author: JW
    /// Handles turning the flashlight on and off, raycasting and sending this to the moth
    /// </summary>
    public class Flashlight : MonoBehaviour
    {
        [Header("Moth")]
        [SerializeField] private GameObject moth;

        [Header("Flashlight")]
        [SerializeField] private float rayDistance = 20f;
        [SerializeField] private Vector3 rayDirection = Vector3.forward;
        [SerializeField] private Vector3 rayOffset = Vector3.zero;
        [SerializeField] private Vector3 rayPoint;
        [SerializeField] private bool isOn = false;

        /// <summary>
        /// Toggle the light on or off. alternativly sets the light on or off
        /// </summary>
        /// <param name="setValue">0: toggle\n1: True\n2: False</param>
        public void ToggleOn(int setValue=0)
        {
            switch (setValue)
            {
                case 0:
                    isOn = !isOn; // Set it to the oposite of its current state
                    break;
                case 1:
                    isOn = true; 
                    break;
                case 2:
                    isOn = false;
                    break;
                default:
                    isOn = !isOn; // Set it to the oposite of its current state
                    break;
            }
            
            Debug.Log(isOn);
        }

        private void FixedUpdate()
        {
            if (isOn)
            {
                var lightHit = Physics.Raycast(transform.position + rayOffset, rayDirection, out RaycastHit hitInfo, rayDistance);

                if (lightHit)
                {
                    rayPoint = hitInfo.point;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Debug.DrawRay(transform.position + rayOffset, rayDirection, Color.red, rayDistance);
        }
    } 
}