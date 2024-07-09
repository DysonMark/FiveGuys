using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{
    public class BombSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource bombTicking;

        [SerializeField] private AudioSource bombDefused;
        
        public DefuseTheBomb bombDefusedCheck;
        
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<AudioSource>().Play();
        }

        // Update is called once per frame
        void Update()
        {
            PauseAndPlay();
        }

        private void PauseAndPlay()
        {
            if (bombDefusedCheck.bombHasBeenDefused == false)
            {
                bombDefused.Pause();
            }
            else if (bombDefusedCheck.bombHasBeenDefused == true)
            {
                bombTicking.Pause();
                Invoke("PlayBombDefusedSound", 1);
            }
        }
        
        private void PlayBombDefusedSound()
        {
            bombDefused.UnPause();
        }
        
        
    }
}
