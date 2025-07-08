using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace SAE.FiveGuys.Bomb
{
    public class DefuseTheBomb : MonoBehaviour
    {
        // The sequence of wires cut by the player (1: Blue, 2: Red, 3: Yellow, 4: Green)
        private readonly List<int> cutWireSequence = new List<int>();

        // Track if each wire was cut correctly
        private bool blueWireCut = false;
        private bool redWireCut = false;
        private bool yellowWireCut = false;
        private bool greenWireCut = false;

        // Bomb state flags
        public bool isDefused = false;
        public bool hasExploded = false;

        [SerializeField] private UnityEvent onDefused;
        [SerializeField] private BombCountdown countdownTimer;

        // Ensure each wire can only be cut once
        private int blueWireAttempts = 0;
        private int redWireAttempts = 0;
        private int yellowWireAttempts = 0;
        private int greenWireAttempts = 0;

        void Update()
        {
            if (!hasExploded && !isDefused)
            {
                CheckDefusalStatus();
            }
            else if (hasExploded)
            {
                StartCoroutine(HandleExplosionTransition());
            }
        }

        /// <summary>
        /// Handles the transition after the bomb explodes.
        /// </summary>
        private IEnumerator HandleExplosionTransition()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(3);
        }

        /// <summary>
        /// Called when the blue wire is cut.
        /// </summary>
        public void CutBlueWire()
        {
            if (blueWireAttempts > 0) return;

            cutWireSequence.Add(1);
            blueWireAttempts++;

            if (cutWireSequence.Count == 0 || cutWireSequence[0] != 1)
            {
                hasExploded = true;
            }
            else
            {
                blueWireCut = true;
            }
        }

        /// <summary>
        /// Called when the red wire is cut.
        /// </summary>
        public void CutRedWire()
        {
            if (redWireAttempts > 0) return;

            cutWireSequence.Add(2);
            redWireAttempts++;

            if (cutWireSequence.Count < 2 || cutWireSequence[1] != 2)
            {
                hasExploded = true;
            }
            else
            {
                redWireCut = true;
            }
        }

        /// <summary>
        /// Called when the yellow wire is cut.
        /// </summary>
        public void CutYellowWire()
        {
            if (yellowWireAttempts > 0) return;

            cutWireSequence.Add(3);
            yellowWireAttempts++;

            if (cutWireSequence.Count < 3 || cutWireSequence[2] != 3)
            {
                hasExploded = true;
            }
            else
            {
                yellowWireCut = true;
            }
        }

        /// <summary>
        /// Called when the green wire is cut.
        /// </summary>
        public void CutGreenWire()
        {
            if (greenWireAttempts > 0) return;

            cutWireSequence.Add(4);
            greenWireAttempts++;

            if (cutWireSequence.Count < 4 || cutWireSequence[3] != 4)
            {
                hasExploded = true;
            }
            else
            {
                greenWireCut = true;
            }
        }

        /// <summary>
        /// Checks if the bomb has been successfully defused or if time has run out.
        /// </summary>
        private void CheckDefusalStatus()
        {
            if (blueWireCut && redWireCut && yellowWireCut && greenWireCut)
            {
                isDefused = true;
                onDefused?.Invoke();
            }

            if (countdownTimer != null && countdownTimer.TimeRemaining <= 0)
            {
                hasExploded = true;
            }
        }
    }
}