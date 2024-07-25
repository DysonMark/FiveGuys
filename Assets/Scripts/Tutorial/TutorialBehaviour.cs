using System;
using System.Collections;
using System.Collections.Generic;
using JW.FiveGuys.Teleportation;
using Kandooz.InteractionSystem.Interactions;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SAE.FiveGuys.Tutorial
{
    public class TutorialBehaviour : MonoBehaviour
    {

        [SerializeField] private Scene nextScene;
        [SerializeField] private string sceneName;
        [SerializeField] private float timer;

        public TeleportationController teleport;

        public bool isObjectHasBeenGrab = false;

        public Grabable knowingIfObjectIsSelected;

        public int i = 0;

        public TutorialVoice valueOfY;
        // Start is called before the first frame update
        private void Start()
        {
            Invoke("ToTheNextScene", 3);
        }

        // Update is called once per frame
        private void Update()
        {
            if (teleport.isPlayerTeleporting == true)
            {
                Debug.Log("Player has teleported");
            }
            ObjectHasBeenGrab();
            ToTheNextScene();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "TutorialGrab")
            {
                i = 1;
                ObjectHasBeenGrab();
            }
        }

        private void ObjectHasBeenGrab()
        {
            Debug.Log("Object has been grabbed");
            if (i == 1)
            {
                isObjectHasBeenGrab = true;
            }
            else if (i == 0)
            {
                isObjectHasBeenGrab = false;
            }
        }
        
        private void ToTheNextScene()
        {
            if (valueOfY.y == 1)
            {

                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    Debug.Log("Quit the tutorial/Start the game");
                    SceneManager.LoadScene("Playable1"); //you should change the name of the scene if you wanna load another one
                }
            }
            
        }
    }
}
