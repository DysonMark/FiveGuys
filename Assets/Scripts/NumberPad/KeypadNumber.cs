using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KeypadNumber : MonoBehaviour
{
    //To show the Sequence when entered by the player
    [SerializeField] private TMP_Text displaycurrentSequence;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip keypadDeniedSFX, keypadGrantedSFX;
    
    //To access the NumberPad script
    public NumberPad numberPad;
    
    //Variables for the sequences 
    public string sequence;

    [SerializeField] private UnityEvent OnSolve;

    public void NumberPressed(int index)
    {
        switch (index)
        {
            case 0:
                sequence += 0;
                displaycurrentSequence.text = sequence;
                break;
            case 1:
                sequence += 1;
                displaycurrentSequence.text = sequence;
                break;
            case 2:
                sequence += 2;
                displaycurrentSequence.text = sequence;
                break;
            case 3:
                sequence += 3;
                displaycurrentSequence.text = sequence;
                break;
            case 4:
                sequence += 4;
                displaycurrentSequence.text = sequence;
                break;
            case 5:
                sequence += 5;
                displaycurrentSequence.text = sequence;
                break;
            case 6:
                sequence += 6;
                displaycurrentSequence.text = sequence;
                break;
            case 7:
                sequence += 7;
                displaycurrentSequence.text = sequence;
                break;
            case 8:
                sequence += 8;
                displaycurrentSequence.text = sequence;
                break;
            case 9:
                sequence += 9;
                displaycurrentSequence.text = sequence;
                break;
            case 10:
                SequenceChecker();
                break;
        }
    }
    
    public void SequenceChecker()
    {
        //Win condition for the game 
        if (numberPad.CorrectSequence == sequence)
        {
            displaycurrentSequence.text = ("Access Granted");
            audioSource.clip = keypadGrantedSFX;
            audioSource.Play();
            OnSolved();
        }
        else
        {
            //if the sequence is wrong, it clears the numbers and the player can enter a new sequence 
            displaycurrentSequence.text = ("Access Denied");
            audioSource.clip = keypadDeniedSFX;
            audioSource.Play();
            sequence = string.Empty;
        }
    }

    /// <summary>
    /// Function for after completion of puzzle 
    /// </summary>
    public void OnSolved()
    {
        if (OnSolve != null) { OnSolve?.Invoke(); }
    }

}
