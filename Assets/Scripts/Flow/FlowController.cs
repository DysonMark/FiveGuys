using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;

public class FlowController : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private JW_GOVariable previousTile;
    [SerializeField] private JW_GOVariable currentTile;

    public void TilePressed()
    {
        //Debug.Log(previousTile.Value.ToString());
        //Debug.Log(currentTile.Value.ToString());
        
        if (previousTile != null)
        {
            if (currentTile == null) currentTile.Value = previousTile.Value;
            else
            {
                if (previousTile.Value.transform.position.x > currentTile.Value.transform.position.x)
                {
                    Debug.Log("Went Right");
                }
                else if (previousTile.Value.transform.position.x < currentTile.Value.transform.position.x)
                {
                    Debug.Log("Went Left");
                }
                else if (previousTile.Value.transform.position.z > currentTile.Value.transform.position.z)
                {
                    Debug.Log("Went Up");
                }
                else if (previousTile.Value.transform.position.z < currentTile.Value.transform.position.z)
                {
                    Debug.Log("Went Down");
                }
            }
            currentTile.Value = previousTile.Value;
        }
        else Debug.Log("Previous tile is null");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (previousTile != null) { currentTile.Value = previousTile.Value; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
