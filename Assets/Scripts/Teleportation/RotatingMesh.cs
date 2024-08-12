using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMesh : MonoBehaviour
{

    //summary: rotates the gameobject at a certain speed overtime

    [SerializeField] private float rotationSpeed; //determines the rotation speed of the gameobject

    
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); //rotates the gameobject around the y-axis overtime
    }
}
