using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JW.FiveGuys.LightMoth;
public class TutorialProgression : MonoBehaviour
{
    public Flashlight activateFlash;
    [SerializeField] private GameObject cameraRigPos;
    [SerializeField] private List<Vector3> tutorialPoints = new List<Vector3>();
    [SerializeField] private int pointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //cameraRigPos.transform.position = new Vector3((float)vectorX, (float)vectorY, (float)vectorZ);
        //cameraRigPos.transform.eulerAngles = new Vector3(0, 280, 0);
    }

    // Update is called once per frame
    void Update()
    { 
    }
    
    public void ToNextTask()
    {
        //Deliver the line and then tp to next task
        Debug.Log("ToNextTask");
            Invoke("ChangeCameraRigPosition", 1);
    }

    private void ChangeCameraRigPosition()
    {
        cameraRigPos.transform.position = tutorialPoints[pointIndex];
        pointIndex++;
        Debug.Log($"Point Index: {pointIndex}");
    }
}
