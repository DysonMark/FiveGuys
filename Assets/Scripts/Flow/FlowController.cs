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
        if (isSolved) return;
        else
        {
            if (previousTile.Value != null)
            {
                if (currentTile.Value == null)
                {
                    currentTile.Value = previousTile.Value;
                }

                TileController previous = previousTile.Value.GetComponent<TileController>();
                TileController current = currentTile.Value.GetComponent<TileController>();

                if (previous.Type == "start") varient = previous.Varient;

                if ((previous.Varient == current.Varient) && (current.IsPathable && previous.IsPathable))
                {
                    if (previousTile.Value.transform.position.z > currentTile.Value.transform.position.z)
                    {
                        previous.TogglePath("left", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("right", true);
                        current.TogglePath("middle", true);

                        Debug.Log("Went Right");
                    }
                    else if (previousTile.Value.transform.position.z < currentTile.Value.transform.position.z)
                    {
                        previous.TogglePath("right", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("left", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Left");
                    }
                    else if (previousTile.Value.transform.position.y > currentTile.Value.transform.position.y)
                    {
                        previous.TogglePath("up", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("down", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Up");
                    }
                    else if (previousTile.Value.transform.position.y < currentTile.Value.transform.position.y)
                    {
                        previous.TogglePath("down", true);
                        previous.TogglePath("middle", true);

                        current.TogglePath("up", true);
                        current.TogglePath("middle", true);
                        Debug.Log("Went Down");
                    }
                }
                currentTile.Value = previousTile.Value;
            }
            else
            {
                currentTile.Value = previousTile.Value;
            }

            isSolved = !CheckWin();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        previousTile.Value = secondTile;
        currentTile.Value = startTile;
        if (previousTile.Value != null) { currentTile.Value = previousTile.Value; }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
