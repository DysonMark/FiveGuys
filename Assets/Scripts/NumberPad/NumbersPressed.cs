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
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip keypadDeniedSFX, keypadGrantedSFX;

    public bool flag1 = false;
    public bool flag2 = false;
    public bool flag3 = false;
    public bool flag4 = false;

    [SerializeField] private UnityEvent OnSolve;

    public void Button1()
    {
        flag1 = true;
    }

    public void Button2()
    {
        flag2 = true;
    }
    public void Button3()
    {
        flag3 = true;
    }
    public void Button4()
    {
        flag4 = true;
    }

    public void PuzzleCompletion()
    {
        if (flag1 == true && flag2 == true && flag3 == true && flag4 == true)
        {
            audioSource.clip = keypadGrantedSFX;
            audioSource.Play();            
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
