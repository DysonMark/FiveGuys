using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class KeypadNumber : MonoBehaviour
{
    //To show the Sequence when entered by the player
    [SerializeField] private TMP_Text displaycurrentSequence;

    //To access the NumberPad script
    public NumberPad numberPad;
    
    //Variables for the sequences 
    public string sequence;

    public void NumberPressed(int index)
    {
        switch (index)
        {
            case 0:
                print("Works");
                sequence += 0;
                displaycurrentSequence.text = sequence;
                Debug.Log("Llama");
                break;
            case 1:
                sequence += 1;
                displaycurrentSequence.text = sequence;
                Debug.Log("Llama");

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
        if (numberPad.CorrectSequence == sequence)
        {
            displaycurrentSequence.text = ("Access Granted");
            //Win condition for the game 
        }
        else
        {
            //if the sequence is wrong, it clears the numbers and the player can enter a new sequence 
            displaycurrentSequence.text = ("Access Denied");
            sequence = string.Empty;
        }
        
    }

    public void OnSolved()
    {
        //Function for after completion of puzzle 
    }
}
