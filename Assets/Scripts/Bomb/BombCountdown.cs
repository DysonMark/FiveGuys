using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.FiveGuys.Bomb
{
    public class BombCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdown;
        [SerializeField] private GameObject bombObject;

        private int counting;
        private float holdCounting = 600;
        private float subtract = 1;
        public int bombChecker = 0;

        public DefuseTheBomb bombOff;

        // Start is called before the first frame update
        void Start()
        {
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
            countdown.text = "600";
            int.TryParse(countdown.text, out counting);
        }

        private void NumbersGoingDown()
        {
            holdCounting -= subtract * Time.deltaTime;
            counting = (int)holdCounting;
            countdown.text = ((int)counting).ToString();
            Debug.Log(counting);
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
            else
            {
                bombChecker = 0;
            }
        }
    }
}

