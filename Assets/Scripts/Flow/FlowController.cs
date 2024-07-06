using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;
using UnityEngine.Events;

namespace JW.FiveGuys.Flow
{
    public class FlowController : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] private int varient = 0;
        [SerializeField] private JW_L_GOVariable grid;

        [Header("Movement")]
        [SerializeField] private Vector2Int currentPosition = Vector2Int.zero;
        [SerializeField] private TileController currentTile;

        [Header("Puzzle")]
        [SerializeField] private bool isSolved = false;
        [SerializeField] private UnityEvent onSolve;

        /// <summary>
        /// Checks all the tiles of type "end"
        /// </summary>
        /// <returns>bool: true if none of the end tiles are pathable, otherwise returns false</returns>
        public bool CheckWin()
        {
            List<bool> endConditions = new List<bool>(); // Will conain all the current states of all the end tiles
            foreach (var item in grid.Values) // Go through all the tiles
            {
                TileController tile = item.GetComponent<TileController>(); // Get the tile information
                if (tile.Type == TileController.TileType.end) endConditions.Add(tile.IsPathable); // Add the tile if it is an end type
            }

            return !endConditions.Contains(true); // Check if any of the tiles are still pathable, ie. not visited yet
        }

        public void TilePressed()
        {
            // 
        }

        /// <summary>
        /// Moves the "cursor" by the given amount
        /// </summary>
        /// <param name="moveBy">Vector2Int: amount to move by</param>
        public void MovePosition(Vector2Int moveBy)
        {
            if (CheckValidMove(moveBy)) // Only proceed to move the tile when the move is valid
            {
                Debug.LogError("Position moved");
                // on the current tile, draw the line in the direction of the move
                TileController.Directions drawDirection = DirectionFromVector(moveBy);
                currentTile.TogglePath(drawDirection, true);

                // get the new position
                currentPosition += moveBy;

                // get the tile in the new position
                currentTile = grid.Values[GetIndex(currentPosition, 3)].GetComponent<TileController>();

                // draw the connecting line on the new tile
                drawDirection = DirectionFromVector(-moveBy);
                currentTile.TogglePath(drawDirection, true);

                // Check if we are at the end
                isSolved = CheckWin();
                if (isSolved) { onSolve?.Invoke(); } // Invoke the events to be excecuted when the puzzle is solved
            }
        }

        /// <summary>
        /// Gives the index in the list from a Vector2Int
        /// </summary>
        /// <param name="vector">Vector2Int: The 2D index</param>
        /// <param name="cols">int: How many collumns the grid has</param>
        /// <returns>int: The integer index on the grid from the 2D vector</returns>
        private int GetIndex(Vector2Int vector, int cols)
        {
            int index = (vector.y * cols) + vector.x;
            return index;
        }

        /// <summary>
        /// Gives the cardinal direction in enum form from the vector provided
        /// </summary>
        /// <param name="vector">Vector2Int: Direction in vector form</param>
        /// <returns>enum based on the provided vector (anything other than an exact unit cardinal direction gives middle)</returns>
        private TileController.Directions DirectionFromVector(Vector2Int vector)
        {
            if (vector == Vector2Int.down)
            {
                return TileController.Directions.down;
            }
            else if (vector == Vector2Int.up)
            {
                return TileController.Directions.up;
            }
            else if (vector == Vector2Int.right)
            {
                return TileController.Directions.right;
            }
            else if (vector == Vector2Int.left)
            {
                return TileController.Directions.left;
            }
            else
            {
                return TileController.Directions.middle;
            }
        }

        /// <summary>
        /// Checks whether the attempted move is valid
        /// </summary>
        /// <param name="moveBy">Vector2Int: How much to move by</param>
        /// <param name="cols">int: How many collumns are in the grid</param>
        /// <param name="rows">int: How many rows are in the grid</param>
        /// <returns>bool: false if any bounds are exceeded or the new tile is full, true otherwise</returns>
        private bool CheckValidMove(Vector2Int moveBy, int cols = 3, int rows = 3)
        {
            // Check puzzle state
            if (isSolved)
            {
                Debug.LogWarning("Puzzle is already solved");
                return false;
            }
            // Check the bounds
            else if (currentPosition.y + moveBy.y < 0)
            {
                Debug.LogWarning("Negative row bounds exceeded");
                return false;
            }
            else if (currentPosition.y + moveBy.y >= rows)
            {
                Debug.LogWarning("Positive row bounds exceeded");
                return false;
            }
            else if (currentPosition.x + moveBy.x < 0)
            {
                Debug.LogWarning("Negative col bounds exceeded");
                return false;
            }
            else if (currentPosition.x + moveBy.x >= cols)
            {
                Debug.LogWarning("Positive col bounds exceeded");
                return false;
            }
            // Tile checks
            else
            {
                TileController checkTile = grid.Values[GetIndex(currentPosition+moveBy, 3)].GetComponent<TileController>();

                if (checkTile == null) // Does the tile exist?
                {
                    Debug.LogWarning("Tile does not exist");
                    return false;
                }
                else // Yes it does
                {
                    if (!checkTile.IsPathable) // Is the tile full yet?
                    {
                        Debug.LogWarning("Tile is not pathable");
                        return false;
                    }
                    else // No errors up to this point, so it must be a valid move!
                    {
                        Debug.Log("Move is valid");
                        return true;
                    }
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MovePosition(new Vector2Int(0, 1));
                Debug.Log($"Coord: ({currentPosition.x},{currentPosition.y}) | Index: {GetIndex(currentPosition, 3)}");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MovePosition(new Vector2Int(0, -1));
                Debug.Log($"Coord: ({currentPosition.x},{currentPosition.y}) | Index: {GetIndex(currentPosition, 3)}");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MovePosition(new Vector2Int(-1, 0));
                Debug.Log($"Coord: ({currentPosition.x},{currentPosition.y}) | Index: {GetIndex(currentPosition, 3)}");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MovePosition(new Vector2Int(1, 0));
                Debug.Log($"Coord: ({currentPosition.x},{currentPosition.y}) | Index: {GetIndex(currentPosition, 3)}");
            }
        }
    } 
}
