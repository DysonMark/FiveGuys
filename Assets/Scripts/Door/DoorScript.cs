using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] public bool isOpened;
    [SerializeField] public float turningSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), turningSpeed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isOpened = true;
    }

}
