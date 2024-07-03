using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.FiveGuys.Bomb
{
    public class BombCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdown;

        private int counting = 30;

        // Start is called before the first frame update
        void Start()
        {
            countdown = GetComponent<TextMeshProUGUI>();

        }

        // Update is called once per frame
        void Update()
        {
            counting = int.Parse(countdown.text);
            for (int i = 0; i < counting; i++)
            {
                counting -= 1;
                Debug.Log(counting);
            }
        }
    }
}

