using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Kandooz.ScriptableSystem;

namespace SAE.FiveGuys.Bomb
{
    public class BombCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdown;
        [SerializeField] private GameObject bombObject;

        [SerializeField] private IntVariable counting;
        [SerializeField] private float holdCounting = 600;
        [SerializeField] private float subtract = 1;

        // Start is called before the first frame update
        void Start()
        {
            countdown = GetComponent<TextMeshProUGUI>();
            holdCounting = counting.Value;

        }

        // Update is called once per frame
        void Update()
        {
            //TextToInt();
            NumbersGoingDown(); 
        }

        private void TextToInt()
        {
            countdown.text = "600";
            //int.TryParse(countdown.text, out counting.Value);
        }

        private void NumbersGoingDown()
        {
            holdCounting -= subtract * Time.deltaTime;
            counting.Value = (int)holdCounting;
            countdown.text = ((int)counting.Value).ToString();
            Debug.Log(counting);
        }
    }
}

