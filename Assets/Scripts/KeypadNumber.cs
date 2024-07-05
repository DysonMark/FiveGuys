using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadNumber : MonoBehaviour
{
    private int Digit1;
    private int Digit2;
    private int Digit3;
    private int Digit4;
    private int Key1;
    private int Key2;
    private int Key3;
    private int Key4;
    public TMP_Text Keydisplay1;
    public TMP_Text Keydisplay2;
    public TMP_Text Keydisplay3;
    public TMP_Text Keydisplay4;
    void Start()
    {
        //Sequence Generator
        Digit1 = Random.Range(0, 10);
        Digit2 = Random.Range(0, 10);
        Digit3 = Random.Range(0, 10);
        Digit4 = Random.Range(0, 10);
        //Displaying of digits
        Keydisplay1.text = Digit1.ToString();
        Keydisplay2.text = Digit2.ToString();
        Keydisplay3.text = Digit3.ToString();
        Keydisplay4.text = Digit4.ToString();
    }   
    void Update()
    {
        // For the door to open
        if (Key1 == Digit1 && Key2 == Digit2 && Key3 == Digit3 && Key4 == Digit4) 
            ; 
        //With the help of colliders figure the keys which are pressed 


    }
}
