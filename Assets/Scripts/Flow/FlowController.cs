using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;

namespace JW.FiveGuys.Flow
{
    public class FlowController : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] private GameObject startTile;
        [SerializeField] private GameObject secondTile;
        [SerializeField] private List<TileController> ends = new List<TileController>();
        [SerializeField] private bool isSolved = false;
        [SerializeField] private TileController currentTile;
        [SerializeField] private int varient = 0;
        [SerializeField] private JW_L_GOVariable grid;

        [Header("Movement")]
        [SerializeField] private Vector2Int currentPosition = Vector2Int.zero;

        public bool CheckWin()
        {
            List<bool> endConditions = new List<bool>();
            foreach (var item in ends)
            {
                endConditions.Add(item.PathCount >= 1);
            }

            return endConditions.Contains(false);
        }

        public void TilePressed()
        {
            // 
        }

        public void MovePosition(Vector2Int moveBy)
        {
            // on the current tile, draw the line in the direction of the move
            TileController.directions drawDirection = DirectionFromVector(moveBy);
            currentTile.TogglePath(drawDirection, true);
            
            // get the new position
            currentPosition += moveBy;

            // get the tile in the new position
            currentTile = grid.Values[GetIndex(currentPosition, 3)].GetComponent<TileController>();

            // draw the connecting line on the new tile
            drawDirection = DirectionFromVector(-moveBy);
            currentTile.TogglePath(drawDirection, true);
        }

        private int GetIndex(Vector2Int vector, int cols)
        {
            int index = (vector.y * cols) + vector.x;
            return index;
        }

        private TileController.directions DirectionFromVector(Vector2Int vector)
        {
            if (vector == Vector2Int.down)
            {
                return TileController.directions.down;
            }
            else if (vector == Vector2Int.up)
            {
                return TileController.directions.up;
            }
            else if (vector == Vector2Int.right)
            {
                return TileController.directions.right;
            }
            else if (vector == Vector2Int.left)
            {
                return TileController.directions.left;
            }
            else
            {
                return TileController.directions.middle;
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
