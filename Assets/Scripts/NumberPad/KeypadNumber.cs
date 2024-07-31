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
  /*public void NumberPressed(int number)
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
    }*/
    public void numberPressed(int index)
    {
        switch (index)
        {
            case 0:
                currentSequence.Add(0);
                break;
            case 1:
                currentSequence.Add(1);
                break;
            case 2:
                currentSequence.Add(2);
                break;
            case 3:
                currentSequence.Add(3);
                break;
            case 4:
                currentSequence.Add(4);
                break;
            case 5:
                currentSequence.Add(5);
                break;
            case 6:
                currentSequence.Add(6);
                break;
            case 7:
                currentSequence.Add(7);
                break;
            case 8:
                currentSequence.Add(8);
                break;
            case 9:
                currentSequence.Add(9);
                break;
            case 10:
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
                break;
            

        }
    }
}
