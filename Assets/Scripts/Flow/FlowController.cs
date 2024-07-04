using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;

public class FlowController : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private GameObject startTile;
    [SerializeField] private GameObject secondTile;
    [SerializeField] private List<TileController> ends = new List<TileController>();
    [SerializeField] private bool isSolved = false;
    [SerializeField] private JW_GOVariable previousTile;
    [SerializeField] private JW_GOVariable currentTile;
    [SerializeField] private int varient = 0;

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
        if (isSolved) return; // Don't do anything if solved
        else
        {
            if (previousTile.Value != null) // The previous tile is the new tile. If it exists
            {
                if (currentTile.Value == null) // And we do not yet have a current tile, 
                {
                    currentTile.Value = previousTile.Value; // It becomes the current tile as well
                }

                // Get the tile controllers for tile info
                TileController previous = previousTile.Value.GetComponent<TileController>();
                TileController current = currentTile.Value.GetComponent<TileController>();

                if (previous.Type == "start") varient = previous.Varient; // if our tile is a starting tile, set our variant to its

                // If we are the same varient and new tile is pathable (less than 2 paths on it)
                if ((previous.Varient == current.Varient) && (previous.IsPathable)) 
                {
                    // Show the correct path on the new and old tile
                    if (previousTile.Value.transform.position.z > currentTile.Value.transform.position.z)
                    {
                        previous.TogglePath("right", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("left", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Right");
                    }
                    else if (previousTile.Value.transform.position.z < currentTile.Value.transform.position.z)
                    {
                        previous.TogglePath("left", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("right", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Left");
                    }
                    else if (previousTile.Value.transform.position.y > currentTile.Value.transform.position.y)
                    {
                        previous.TogglePath("down", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("up", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Up");
                    }
                    else if (previousTile.Value.transform.position.y < currentTile.Value.transform.position.y)
                    {
                        previous.TogglePath("up", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("down", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Down");
                    }
                }

                // Set the current tile to the one we just hit
                currentTile.Value = previousTile.Value;
            }

            isSolved = !CheckWin(); // Check if everything is solved
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        previousTile.Value = secondTile;
        currentTile.Value = startTile;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
