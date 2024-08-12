using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    //summary: This script checks if any gameobject enters the box collider. If it does, it rotates the door to give access to the next room 

    [SerializeField] public bool isOpened; //
    [SerializeField] public float turningSpeed; //determines how fast the door opens
    
    void Update()
    {
        if (isOpened == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), turningSpeed * Time.deltaTime); //rotates the door 90 degrees with respect to the turningSpeed
        }
    }


    private void OnTriggerEnter(Collider other) //functions runs when a gameobject with a collider enters this gameobject's collider
    {
        isOpened = true; //turns the bool value to true to open the door
    }

}
