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
    public List<int> currentSequence = new List<int>();

    //Function for the number pressed by the player 
    public void NumberPressed(int number)
    {
        //sequence which will be printed when the player eneters the number
        sequence += number.ToString();
        //Displays for the player
        displaycurrentSequence.text = sequence;
        //Adds the number to be checked in the end
        currentSequence.Add(number);

        //When the player enters 4 digits, it checks if the digits entered is the correct sequence 
        if (currentSequence.Count >= 4) 
        {
            bool check = Enumerable.SequenceEqual( numberPad.correctSequence, currentSequence);
            if (check == true)
            {
                displaycurrentSequence.text = ("Access Granted");
                //Win condition for the game 
            }
            else
            {
                //if the sequence is wrong, it clears the numbers and the player can enter a new sequence 
                displaycurrentSequence.text = ("Access Denied");
                currentSequence.Clear();
            }
        }
    }
}
