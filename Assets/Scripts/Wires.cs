using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{


    [SerializeField] private bool isRotated;
    [SerializeField] private bool isConnected;
    // Start is called before the first frame update
    void Start()
    {
        isRotated = false;
        isConnected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wire"))
        {
            isConnected = true;
        }
        
            if (!isRotated)
            {
                //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, ;
                transform.Rotate(0f, 0f, 90f);
                isRotated = true;
            }
        
    }

    private void OnTriggerExit(Collider other)
    {

        
            isRotated = false;

        isConnected = false;
      
    }

}
