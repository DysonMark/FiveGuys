using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.FiveGuys.Bomb
{
    /// <summary>
    /// Handles the bomb countdown timer, display, and bomb state UI.
    /// </summary>
    public class BombCountdown : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI countdownText;

        [Header("Bomb Logic")]
        [Tooltip("Reference to the DefuseTheBomb script controlling bomb state.")]
        [SerializeField] private DefuseTheBomb bombLogic;

        [Header("Timer Settings")]
        [Tooltip("Initial countdown time in seconds.")]
        [SerializeField] private float initialTime = 900f; // 15 minutes by default

        public float TimeRemaining { get; private set; }
        public bool IsCountingDown => TimeRemaining > 0 && !IsBombStopped;

        public bool IsBombStopped => bombLogic != null && (bombLogic.isDefused || bombLogic.hasExploded);

        private void Awake()
        {
            if (countdownText == null)
            {
                countdownText = GetComponent<TextMeshProUGUI>();
                if (countdownText == null)
                {
                    Debug.LogError("BombCountdown: No TextMeshProUGUI assigned or found on GameObject.");
                }
            }
            if (bombLogic == null)
            {
                Debug.LogWarning("BombCountdown: DefuseTheBomb reference not set in inspector.");
            }
        }

        private void Start()
        {
            TimeRemaining = initialTime;
            UpdateCountdownDisplay();
        }

        private void Update()
        {
            if (!IsBombStopped)
            {
                UpdateTimer();
            }
            UpdateCountdownDisplay();
        }

        /// <summary>
        /// Decreases the timer if the bomb is active.
        /// </summary>
        private void UpdateTimer()
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                if (TimeRemaining < 0)
                {
                    TimeRemaining = 0;
                }
            }
        }

        /// <summary>
        /// Updates the countdown text based on bomb state.
        /// </summary>
        private void UpdateCountdownDisplay()
        {
            if (bombLogic != null)
            {
                if (bombLogic.isDefused)
                {
                    countdownText.text = "OFF";
                    return;
                }
                if (bombLogic.hasExploded)
                {
                    countdownText.text = "WRONG";
                    return;
                }
            }

            int minutes = Mathf.FloorToInt(TimeRemaining / 60f);
            int seconds = Mathf.FloorToInt(TimeRemaining % 60f);
            countdownText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}

