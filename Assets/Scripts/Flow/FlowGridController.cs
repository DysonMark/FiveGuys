using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField] private List<GameObject> grid = new List<GameObject>();


        public void SpawnGrid()
        {
            for (int row = 0; row < gridSize.y; row++)
            {
                for (int col = 0; col < gridSize.x; col++)
                {
                    var tile = Instantiate(gridTile, transform.position + new Vector3(
                        tileSize.x * col, 
                        0, 
                        tileSize.y * row
                        ), Quaternion.identity);
                    grid.Add(tile);
                }
            }

            isSpawned = true;
        }

        public void DestroyGrid()
        {
            if (grid.Count > 0)
            {
                for (int i = grid.Count - 1; i >= 0; i--)
                {
                    DestroyImmediate(grid[i]);
                }
                grid.Clear();
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
