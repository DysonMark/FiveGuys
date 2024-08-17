using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JW.FiveGuys.LightMoth;
using Kandooz.InteractionSystem.Interactions;

public class TutorialProgression : MonoBehaviour
{
    public Flashlight activateFlash;
    [SerializeField] private GameObject cameraRigPos;
    [SerializeField] private List<Vector3> tutorialPoints = new List<Vector3>();
    [SerializeField] private int pointIndex = 0;
    public VRButton buttonState;
    private bool callFunction = true;
    public int action = 0;

    // Start is called before the first frame update
    void Start()
    {
        //cameraRigPos.transform.position = new Vector3((float)vectorX, (float)vectorY, (float)vectorZ);
        //cameraRigPos.transform.eulerAngles = new Vector3(0, 280, 0);
    }

    // Update is called once per frame
    void Update()
    {
        FirstVoiceAction();
        TeleportationAction();
        ButtonHasBeenClicked();
    }

    public void ToNextTask()
    {
        //Deliver the line and then tp to next task
        Debug.Log("ToNextTask");
        if (callFunction)
        {
            Invoke("ChangeCameraRigPosition", 1);
            StartCoroutine(CooldownFunction(2.0f));
            callFunction = false;
        }
    }

    private void ChangeCameraRigPosition()
    {
        cameraRigPos.transform.position = tutorialPoints[pointIndex];
        pointIndex++;
        Debug.Log($"Point Index: {pointIndex}");
    }

    IEnumerator CooldownFunction(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        callFunction = true;
    }

    public void FlashLightHasBeenPicked()
    {
        action = 1;
    }

    public void FirstVoiceAction()
    {
        if (pointIndex == 2)
        {
            action = 2;
        }
    }

    public void ButtonHasBeenClicked()
    {
        if (buttonState.isClicked == true)
        {
            ToNextTask();
        }
    }

    public void TeleportationAction()
    {
        if (pointIndex >= 3)
        {
            action = 3;
        }
    }

}
