using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using JW.FiveGuys.Flow;

namespace JW.FiveGuys.Flow
{
    [CustomEditor(typeof(FlowGridController))]
    public class FlowGridEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            FlowGridController gridController = (FlowGridController)target;

            if(GUILayout.Button("Spawn Grid"))
            {
                gridController.SpawnGrid();
            }

            if (GUILayout.Button("Destroy Grid"))
            {
                gridController.DestroyGrid();
            }
        }
    } 
}
