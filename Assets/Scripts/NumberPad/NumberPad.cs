using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberPad : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private int number;

    private void OnTriggerEnter(Collider other)
    {
        onPressed.Invoke();
    }
}
