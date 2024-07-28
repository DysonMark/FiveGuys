using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class NumberPad : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private int number;

    //Variables for each digit for the correct sequence 
    private int Digit1;
    private int Digit2;
    private int Digit3;
    private int Digit4;

    //Display for the digits for the correct sequence
    public TMP_Text Keydisplay1;
    public TMP_Text Keydisplay2;
    public TMP_Text Keydisplay3;
    public TMP_Text Keydisplay4;

    //
    public List<int> correctSequence = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        onPressed.Invoke();
    }
    void Start()
    { 
        //Sequence Generator
        Digit1 = Random.Range(0, 10);
        Digit2 = Random.Range(0, 10);
        Digit3 = Random.Range(0, 10);
        Digit4 = Random.Range(0, 10);

        //Adding the digits to the correct sequence
        correctSequence.Add(Digit1);
        correctSequence.Add(Digit2);
        correctSequence.Add(Digit3);
        correctSequence.Add(Digit4);

        //Displaying of digits
        Keydisplay1.text = Digit1.ToString();
        Keydisplay2.text = Digit2.ToString();
        Keydisplay3.text = Digit3.ToString();
        Keydisplay4.text = Digit4.ToString();
    }
}
