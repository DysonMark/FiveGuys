using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;

namespace JW.FiveGuys.Flow
{
    public class FlowGridController : MonoBehaviour
    {
        [Header("Grid Set Up")]
        [SerializeField] private bool isSpawned = false;
        [SerializeField] private GameObject gridTile;
        [SerializeField] private Vector2 tileSize = Vector2Int.one;
        [SerializeField] private Vector2Int gridSize = Vector2Int.one;

        [Header("Grid")]
        [SerializeField] private JW_L_GOVariable grid;


        public void SpawnGrid()
        {
            for (int row = 0; row < gridSize.y; row++)
            {
                for (int col = 0; col < gridSize.x; col++)
                {
                    var tile = Instantiate(gridTile, transform.position + new Vector3(
                        0, 
                        tileSize.x * col, 
                        tileSize.y * row
                        ), gridTile.transform.rotation, gameObject.transform);
                    grid.Value = tile;
                }
            }

            isSpawned = true;
        }

        public void DestroyGrid()
        {
            if (grid.Values.Count > 0)
            {
                for (int i = grid.Values.Count - 1; i >= 0; i--)
                {
                    DestroyImmediate(grid.Values[i]);
                }
                grid.Values.Clear();
            }

            isSpawned = false;
        }

        private void OnEnable()
        {
            if (!isSpawned) SpawnGrid();
        }

        private void OnDisable()
        {
            if (isSpawned) DestroyGrid();
        }
    } 
}
