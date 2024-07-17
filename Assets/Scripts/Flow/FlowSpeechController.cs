using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;
using Unity.Collections;
using TMPro;

namespace JW.FiveGuys.Flow
{
    /// <summary>
    /// Author: JW
    /// A script for recognising speech phrases in order to control the Flow puzzle's cursor.
    /// NOTE: This script needs to be on the same GameObject as the FlowController in order to work
    /// </summary>
    public class FlowSpeechController : MonoBehaviour
    {
        [SerializeField] [ReadOnly] private string[] keywords = new string[] {
            "Kill",
            "Fun",
            "Murder",
            "Lama",
            "Blue",
            "Jamal"
        };
        [SerializeField] private FlowController controller;
        private KeywordRecognizer recognizer;

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<FlowController>();

            // Initialize the speech recognition system
            recognizer = new KeywordRecognizer(keywords);
            recognizer.OnPhraseRecognized += OnPhraseRecognized;
            recognizer.Start();
        }

        /// <summary>
        /// Gets called when the system recognises one of the keywords we set. It then simulates that button being pressed
        /// </summary>
        /// <param name="args"></param>
        private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log(args.text);

            switch (args.text)
            {
                case "U":
                    controller.ButtonPressed(1);
                    break;
                case "R":
                    controller.ButtonPressed(2);
                    break;
                case "D":
                    controller.ButtonPressed(3);
                    break;
                case "L":
                    controller.ButtonPressed(4);
                    break;
                case "S":
                    controller.ButtonPressed(-1);
                    break;
                case "A":
                    controller.ButtonPressed(-2);
                    break;
                default:
                    break;
            }
        }
    } 
}
