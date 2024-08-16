using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    //summary: controls the transparency of the black image to aid transitions between scenes

    [SerializeField] private RawImage fader; //to access the image
    [SerializeField] private bool isTransparent; //bool check if the canvas should be transparent or not


    

    
    void Start()
    {
        fader = GetComponent<RawImage>(); //gets the RawImage component from the inspector
        isTransparent = true; //set isTransparent to true

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

        if (isTransparent)
        {


                fader.CrossFadeAlpha(1f, 1.5f * Time.deltaTime, true);
            
            
        }
    }

    private void FadeOut() //turns the transparency on gradually
    {

        if (!isTransparent)
        {

            fader.CrossFadeAlpha(0f, 1.5f * Time.deltaTime, true);

        }
    }

    public void SetHasFadedFalse()
    {
        isTransparent = false;
    }

}
