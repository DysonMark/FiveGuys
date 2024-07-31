using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumbersPressed : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private int number;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("works");
        onPressed.Invoke();
    }
}
