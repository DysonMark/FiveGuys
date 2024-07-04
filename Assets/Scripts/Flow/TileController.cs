using Kandooz.ScriptableSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [Header("Pathways")]
    [SerializeField] private GameObject uPath;
    [SerializeField] private GameObject dPath;
    [SerializeField] private GameObject lPath;
    [SerializeField] private GameObject rPath;
    [SerializeField] private GameObject mPath;

    [Header("FlowController")]
    [SerializeField] private JW_GOVariable scriptableTile;
    [SerializeField] private GameEvent tilePressed;
    [SerializeField] private string type = "tile";
    [SerializeField] private int varient = 0;
    [SerializeField] private bool isPathable = true;
    [SerializeField] private int pathCount = 0;

    public string Type
    {
        get { return type; }
    }
    public int Varient
    { 
        get { return varient; } 
        set { varient = value; }
    }
    public bool IsPathable { get { return isPathable; } }
    public int PathCount { get { return pathCount; } }

    private void OnEnable()
    {
        //scriptableTile.Value = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        scriptableTile.Value = gameObject;
        Debug.Log($"Tile: {gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        tilePressed.Raise();
    }

    public void TogglePath(string path, bool state)
    {
        switch (path)
        {
            case "up":
                if (!uPath.activeSelf)
                {
                    uPath.SetActive(state);
                    pathCount++;
                }
                break;
            case "down":
                if (!dPath.activeSelf)
                {
                    dPath.SetActive(state);
                    pathCount++;
                }
                break;
            case "left":
                if (!lPath.activeSelf)
                {
                    lPath.SetActive(state);
                    pathCount++;
                }
                break;
            case "right":
                if (!rPath.activeSelf)
                {
                    rPath.SetActive(state);
                    pathCount++;
                }
                break;
            case "middle":
                mPath.SetActive(state);
                break;
            default:
                break;
        }

        if (pathCount >= 1) { isPathable = false; }
    }
}
