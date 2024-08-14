using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JW.FiveGuys.LightMoth;
public class TutorialProgression : MonoBehaviour
{
    public Flashlight activateFlash;
    [SerializeField] private GameObject cameraRigPos;
    private double vectorX = 17.70;

    private double vectorY = 1.50;

    private double vectorZ = -91.50;

    private double vectorXFlash = 17.66;
    private double vectorZFlash = -89.36;
    // Start is called before the first frame update
    void Start()
    {
        cameraRigPos.transform.position = new Vector3((float)vectorX, (float)vectorY, (float)vectorZ);
        cameraRigPos.transform.eulerAngles = new Vector3(0, 280, 0);
    }

    // Update is called once per frame
    void Update()
    { 
        ToNextTask();
    }
    
    private void ToNextTask()
    {
        if (activateFlash.isOn == true)
        {
            //Deliver the line and then tp to next task
            Invoke("ChangeCameraRigPosition", 5);
        }
    }

    private void ChangeCameraRigPosition()
    {
        cameraRigPos.transform.position = new Vector3((float)vectorXFlash, (float)vectorY, (float)vectorZFlash);
    }
}
