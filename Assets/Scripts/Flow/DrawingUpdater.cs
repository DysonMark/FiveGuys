using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace JW.FiveGuys.Flow
{
    /// <summary>
    /// Author: JW
    /// Note: Not In Use. This script was supposed to update the text for the Flow puzzle's button controller to say the cursor's state
    /// </summary>
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
