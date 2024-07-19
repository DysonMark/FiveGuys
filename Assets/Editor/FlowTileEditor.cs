using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using JW.FiveGuys.Flow;

namespace JW.FiveGuys.Flow
{
    [CustomEditor(typeof(TileController))]
    public class FlowTileEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            TileController tile = (TileController)target;

            if (tile.Type == TileController.TileType.blank)
            {
                if (GUILayout.Button("Make Point"))
                {
                    tile.TogglePath(TileController.Directions.middle, true);
                    tile.Type = TileController.TileType.point;
                    tile.SetDefaults();
                }
            }
            else
            {
                if (GUILayout.Button("Make Blank"))
                {
                    tile.TogglePath(TileController.Directions.middle, false);
                    tile.Type = TileController.TileType.blank;
                    tile.PathCount = 0;
                    tile.SetDefaults();
                }
            }

            base.OnInspectorGUI();
        }
    } 
}
