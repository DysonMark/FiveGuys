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

        [SerializeField] private AudioSource bombExplosion;
        public DefuseTheBomb bombDefusedCheck;
        public DefuseTheBomb test;
        
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<AudioSource>().Play();
        }

        // Update is called once per frame
        void Update()
        {
            PauseAndPlay();
            if (test.test == 2)
                PlayBombExplodedSound();
        }

        public void PauseAndPlay()
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

            if (bombDefusedCheck.bombHasExploded == false)
            {
                bombExplosion.Pause();
            }
            
           if (bombDefusedCheck.bombHasExploded == true)
            {
                bombTicking.Pause();
                Invoke("PlayBombExplodedSound", 1);
            }
        }
        
        private void PlayBombDefusedSound()
        {
            bombDefused.UnPause();
        }

        private void PlayBombExplodedSound()
        {
            bombExplosion.UnPause();
        }
        
        
    }
}
