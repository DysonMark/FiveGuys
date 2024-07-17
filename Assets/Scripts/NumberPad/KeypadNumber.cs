using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class KeypadNumber : MonoBehaviour
{
    private int Digit1;
    private int Digit2;
    private int Digit3;
    private int Digit4;

    public TMP_Text Keydisplay1;
    public TMP_Text Keydisplay2;
    public TMP_Text Keydisplay3;
    public TMP_Text Keydisplay4;

    public List<int> correctSequence = new List<int>();
    public List<int> currentSequence = new List<int>();
    void Start()
    {
        //Sequence Generator
        Digit1 = Random.Range(0, 10);
        Digit2 = Random.Range(0, 10);
        Digit3 = Random.Range(0, 10);
        Digit4 = Random.Range(0, 10);
        //Adding the digits to the correct sequence
        correctSequence[0] = Digit1;
        correctSequence[1] = Digit2;
        correctSequence[2] = Digit3;
        correctSequence[3] = Digit4;
        //Displaying of digits
        Keydisplay1.text = Digit1.ToString();
        Keydisplay2.text = Digit2.ToString();
        Keydisplay3.text = Digit3.ToString();
        Keydisplay4.text = Digit4.ToString();
    }   
    void Update()
    {

    }

    public void NumberPressed(int number)
    {
        currentSequence.Add(number);
        if (currentSequence.Count > 3) 
        {
            Enumerable.SequenceEqual(correctSequence, currentSequence);
        }
        else
        {
            currentSequence.Clear();
        }
        
    }
}
