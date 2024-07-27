using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class KeypadNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text displaycurrentSequence;

    public NumberPad numberPad;

    public string sequence;
    public List<int> currentSequence = new List<int>();

    public void NumberPressed(int number)
    {
        sequence += number.ToString();
        displaycurrentSequence.text = sequence;
        currentSequence.Add(number);

        //displaycurrentSequence.text = currentSequence.ToString();

        if (currentSequence.Count == 4) 
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
