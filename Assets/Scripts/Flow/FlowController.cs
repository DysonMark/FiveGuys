using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;
using UnityEngine.Events;
using TMPro;

namespace JW.FiveGuys.Flow
{
    public class FlowController : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] private int varient = 0;
        [SerializeField] private JW_L_GOVariable grid;
        [SerializeField] private GameObject cursor;

        [Header("Movement")]
        [SerializeField] private Vector2Int currentPosition = Vector2Int.zero;
        private Vector2Int startPosition = Vector2Int.zero;
        [SerializeField] private TileController currentTile;
        [SerializeField] private bool isDrawing = false;
        [SerializeField] private TMP_Text drawingButton;

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
                if (tile.Type == TileController.TileType.point) endConditions.Add(tile.IsPathable); // Add the tile if it is an end type
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
                // Get the enum direction we moved in
                TileController.Directions drawDirection = DirectionFromVector(moveBy);

                // If we are drawing, draw the line on the grid
                if (isDrawing)
                {
                    currentTile.TogglePath(drawDirection, true);
                }

                // get the new position
                Debug.LogError("Position moved");
                currentPosition += moveBy;

                // get the tile in the new position
                currentTile = grid.Values[GetIndex(currentPosition, 3)].GetComponent<TileController>();

                // Update cursor position
                cursor.transform.position = currentTile.transform.position;

                if (isDrawing)
                {
                    // Set it to our current varient
                    currentTile.Varient = varient;

                    // draw the connecting line on the new tile
                    drawDirection = DirectionFromVector(-moveBy);
                    currentTile.TogglePath(drawDirection, true);

                    // Check if we are at the end
                    isSolved = CheckWin();
                    if (isSolved) { onSolve?.Invoke(); } // Invoke the events to be excecuted when the puzzle is solved
                }
            }
        }

        public void ButtonPressed(int index)
        {
            switch (index)
            {
                case 1:
                    MovePosition(Vector2Int.up); break;
                case 2:
                    MovePosition(Vector2Int.right); break;
                case 3:
                    MovePosition(Vector2Int.down); break;
                case 4:
                    MovePosition(Vector2Int.left); break;
                case -1:
                    ResetToDefaults(); break;
                case -2:
                    ToggleCursor(); break;
                default:
                    break;
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
                if (isDrawing)
                {
                    TileController checkTile = grid.Values[GetIndex(currentPosition + moveBy, 3)].GetComponent<TileController>();

                    if (checkTile == null) // Does the tile exist?
                    {
                        Debug.LogWarning("Tile does not exist");
                        return false;
                    }
                    else // Yes it does
                    {
                        if (!checkTile.IsPathable) // Is the tile full yet?
                        {
                            if (checkTile.Type == TileController.TileType.point && checkTile.PathCount <= 1) // Yes, but is it a start tile with 1 or fewer paths?
                            {
                                // Report move as valid
                                Debug.Log("Move is valid");
                                return true;
                            }
                            else // No, so it is not valid
                            {
                                Debug.LogWarning("Tile is not pathable");
                                return false;
                            }
                        }
                        else // Tile is pathable
                        {
                            // Tile varient is not 0 (0 is used as a default that can be changed, all the other numbers need to be the same to be a valid move)
                            if (checkTile.Varient != 0 && checkTile.Varient != varient)
                            {
                                Debug.LogWarning("Tile is not a default varient or of the same varient");
                                return false;
                            }
                            else
                            {
                                // Report move as valid
                                Debug.Log("Move is valid");
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    return true; // We don't check for tile validity when drawing so we just say it would work
                }
            }
        }

        private void ToggleCursor()
        {
            if (currentTile.Type == TileController.TileType.point)
            {
                isDrawing = !isDrawing;
                varient = currentTile.Varient;
            }
            else
            {
                isDrawing = false;
            }
            
            if (isDrawing)
            {
                drawingButton.text = "Drawing";
            }
            else
            {
                drawingButton.text = "Not Drawing";
            }
        }

        private void SetDefaults()
        {
            startPosition = currentPosition; // Set the current position as the default

            // Set the current tile to the one at the current position
            currentTile = grid.Values[GetIndex(currentPosition, 3)].GetComponent<TileController>();

            // Set cursor position to current tile
            cursor.transform.position = currentTile.transform.position;
        }

        private void ResetToDefaults()
        {
            if (isSolved) return; // Don't allow reseting the puzzle once it is solved

            currentPosition = startPosition; // Reset the cursor position to what we started at

            foreach (var item in grid.Values) // Go through all the tiles and reset them to their defaults
            {
                TileController tile = item.GetComponent<TileController>();
                tile.SetToDefaults();
            }

            currentTile = grid.Values[GetIndex(currentPosition, 3)].GetComponent<TileController>(); // Set the current tile back to the one we are now currently on

            // Reset cursor position to the starting tile
            cursor.transform.position = currentTile.transform.position;
        }

        private void OnEnable()
        {
            SetDefaults();
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                ResetToDefaults();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ToggleCursor();
            }
        }
    } 
}
