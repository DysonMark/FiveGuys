using Kandooz.Kuest;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NumbersPressed : MonoBehaviour
{
    public TMP_Text Digit1;
    public TMP_Text Digit2;
    public TMP_Text Digit3;
    public TMP_Text Digit4;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip keypadDeniedSFX, keypadGrantedSFX;

    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;
    [SerializeField] private GameObject Button3;
    [SerializeField] private GameObject Button4;

    public bool flag1 = false;
    public bool flag2 = false;
    public bool flag3 = false;
    public bool flag4 = false;

    [SerializeField] private UnityEvent OnSolve;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Button1")
        {
            flag1 = true;
        }
        else if (other.gameObject.name == "Button2")
        {
            flag2 = true;
        }
        else if (other.gameObject.name == "Button3")
        {
            flag3 = true;
        }
        else if (other.gameObject.name == "Button4")
        {
            flag4 = true;
        }
    }

    public void PuzzleCompletion()
    {
        if (flag1 == true && flag2 == true && flag3 == true && flag4 == true)
        {
            audioSource.clip = keypadGrantedSFX;
            audioSource.Play();
            //OnSolved();
        }
        else
        {
            audioSource.clip = keypadDeniedSFX;
            audioSource.Play();
            
        }
    }

    public void OnSolved()
    {
        if (OnSolve != null) { OnSolve?.Invoke(); }
    }
}
