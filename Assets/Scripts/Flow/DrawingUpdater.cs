using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace JW.FiveGuys.Flow
{
    public class DrawingUpdater : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private FlowController controller;
        [SerializeField] private TMP_Text textCanvas;

        private void OnEnable()
        {
            textCanvas = GetComponent<TMP_Text>();
            if (controller == null) { Debug.LogError("No FlowController set"); }
        }
    } 
}
