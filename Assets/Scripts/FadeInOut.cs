using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    //summary: controls the transparency of the black image to aid transitions between scenes

    [SerializeField] private RawImage fader; //to access the image
    [SerializeField] private bool isTransparent; //bool check if the canvas should be transparent or not
    private bool hasFaded; //bool value to check if the canvas has faded in/out

    

    
    void Start()
    {
        fader = GetComponent<RawImage>(); //gets the RawImage component from the inspector
        isTransparent = true; //set isTransparent to true
        hasFaded = true; //set hasFaded to false
    }

    
    void Update()
    {

        if (fader == null)
        {
            return;
        }

        FadeIn();
        FadeOut();
    }

    private void FadeIn() //turns the transparency off gradually
    {

        if (isTransparent && hasFaded)
        {

            int i = 0;

            while (i < 255)
            {
                fader.color = new Color(0, 0, 0, i);
                i++;
            }
            hasFaded = false;
        }
    }

    private void FadeOut() //turns the transparency on gradually
    {

        if (isTransparent && !hasFaded)
        {
            int i = 255;

            while (i > 0)
            {
                fader.color = new Color(0, 0, 0, i);
                i++;
            }
            hasFaded = true;
        }
    }

}
