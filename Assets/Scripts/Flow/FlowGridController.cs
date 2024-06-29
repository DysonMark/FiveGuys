using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.FiveGuys.Flow
{
    /// <summary>
    /// Author: JW
    /// Helps make and manage the grid for the Flow puzzles
    /// </summary>
    public class FlowGridController : MonoBehaviour
    {
        // Variables to spawn in the grid
        [Header("Grid Set Up")]
        [SerializeField] private int cols = 1;
        [SerializeField] private int rows = 1;
        [SerializeField] private GameObject gridTile;
        [SerializeField] private List<GameObject> grid = new List<GameObject>();
        [SerializeField] private Vector3 tileSize = Vector3.one;

        public void SpawnGrid()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var tile = Instantiate(gridTile, transform.position + new Vector3(tileSize.x * col, tileSize.y * row), Quaternion.identity);
                    grid.Add(tile);
                }
            }
        }

        public void DestroyGrid()
        {
            for (int i = grid.Count - 1; i >= 0; i--)
            {
                Destroy(grid[i].gameObject);
            }
        }

        private void OnDestroy()
        {
            if (grid.Count > 0)
            {

            }
        }
    }
}
