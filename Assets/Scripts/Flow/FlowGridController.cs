using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;

namespace JW.FiveGuys.Flow
{
    /// <summary>
    /// Author: JW
    /// A script for spawning in the grid of tiles for the Flow puzzle.
    /// NOTE: Please ensure the grid is empty (all the tile GameObject in the world space for this puzzle are deleted and the scriptable variable list is empty) before spawing in a new grid. This should be checked on putting the prefab into the scene. This might be something I return to at some point. Furthermore, the "point" tiles (starting and ending points for all the varients) need to be set manually after the grid is spawned. I plan to add functionality to the inspector to be able to do it from there, but have not gotten around to it yet or run into a case where this has been completely necesary
    /// </summary>
    public class FlowGridController : MonoBehaviour
    {
        [Header("Grid Set Up")]
        [SerializeField] private bool isSpawned = false;
        [SerializeField] private GameObject gridTile;
        [SerializeField] private Vector2 tileSize = Vector2Int.one;
        [SerializeField] [Tooltip("This is how many collumns and rows to spawn (collumns, rows)")] private Vector2Int gridSize = Vector2Int.one;

        [Header("Grid")]
        [SerializeField] private JW_L_GOVariable grid;

        /// <summary>
        /// Spawns the grid of the specified size using the tile prefab provided. This is stored in the provided scriptable list variable
        /// </summary>
        public void SpawnGrid()
        {
            for (int row = 0; row < gridSize.y; row++)
            {
                for (int col = 0; col < gridSize.x; col++)
                {
                    var tile = Instantiate(gridTile, transform.position + new Vector3(
                        0, 
                        tileSize.x * row, 
                        tileSize.y * col
                        ), gridTile.transform.rotation, gameObject.transform); // Spawn the tile as a child of the GridController's GameObject and offset by the specified size of the tile prefab
                    tile.name = $"Tile({col},{row})"; // Rename it to include the coordinate of the tile to make dragging and dropping or navigating them easier
                    grid.Value = tile; // Add the tile to the list
                    tile.GetComponent<TileController>().SetDefaults(); // Set the tile's default values
                }
            }

            isSpawned = true;
        }

        /// <summary>
        /// Destroys the GameObjects of the tiles and clears the list. Only works if the list is not already empty
        /// </summary>
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
    } 
}
