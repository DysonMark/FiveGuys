using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;

namespace JW.FiveGuys.Flow
{
    public class FlowSpeechController : MonoBehaviour
    {
        [SerializeField] private string[] keywords;
        [SerializeField] private FlowController controller;
        private KeywordRecognizer recognizer;

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<FlowController>();

            recognizer = new KeywordRecognizer(keywords);
            recognizer.OnPhraseRecognized += OnPhraseRecognized;
            recognizer.Start();
        }

        private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log(args.text);

            switch (args.text)
            {
                case "North":
                    controller.ButtonPressed(1);
                    break;
                case "East":
                    controller.ButtonPressed(2);
                    break;
                case "South":
                    controller.ButtonPressed(3);
                    break;
                case "West":
                    controller.ButtonPressed(4);
                    break;
                case "Reset":
                    controller.ButtonPressed(-1);
                    break;
                case "Draw":
                    controller.ButtonPressed(-2);
                    break;
                default:
                    break;
            }
        }
    } 
}
