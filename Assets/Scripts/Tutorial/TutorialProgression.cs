using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JW.FiveGuys.LightMoth;
public class TutorialProgression : MonoBehaviour
{
    private Flashlight activateFlash;
    [SerializeField] private GameObject cameraRigPos;

    // Start is called before the first frame update
    void Start()
    {
        
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
            cameraRigPos.transform.position = transform.position + new Vector3(0, 0, 0);
        }
    }
}
