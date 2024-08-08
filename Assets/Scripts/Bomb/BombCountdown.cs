using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.FiveGuys.Bomb
{
    public class BombCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdown;
        private GameObject bombObject;

        private int counting;
        public float holdCounting = 900;
        private float subtract = 1;
        public int bombChecker = 0;

        public DefuseTheBomb bombOff;

        // Start is called before the first frame update
        void Start()
        {
            bombObject = GameObject.Find("TimerBomb1");
            countdown = GetComponent<TextMeshProUGUI>();

        }

        // Update is called once per frame
        void Update()
        {
            TextToInt();
            NumbersGoingDown();
            DeleteTextOnBomb();
        }

        private void TextToInt()
        {
            countdown.text = "10";
            int.TryParse(countdown.text, out counting);
        }

        private void NumbersGoingDown()
        {
            holdCounting -= subtract * Time.deltaTime;
            counting = (int)holdCounting;
            int minutes = Mathf.FloorToInt(holdCounting / 60);
            int seconds = Mathf.FloorToInt((holdCounting % 60));
            countdown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void DeleteTextOnBomb()
        {
            if (bombOff.bombHasBeenDefused == true)
            {
                bombChecker = 1;
                countdown.text = "OFF";
                counting = 0;
                holdCounting = 0;
            }
            else if (bombOff.bombHasExploded == true)
            {
                bombChecker = 2;
                countdown.text = "WRONG";
            }
            else
            {
                bombChecker = 0;
            }
        }
    }
}

