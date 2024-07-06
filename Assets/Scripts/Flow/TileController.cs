using Kandooz.ScriptableSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.FiveGuys.Flow
{
    public class TileController : MonoBehaviour
    {
        public enum directions
        {
            up,
            down,
            left, 
            right,
            middle
        }
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

        public void TogglePath(directions path, bool state)
        {
            switch (path)
            {
                case directions.up:
                    if (!uPath.activeSelf)
                    {
                        uPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case directions.down:
                    if (!dPath.activeSelf)
                    {
                        dPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case directions.left:
                    if (!lPath.activeSelf)
                    {
                        lPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case directions.right:
                    if (!rPath.activeSelf)
                    {
                        rPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case directions.middle:
                    mPath.SetActive(state);
                    break;
                default:
                    break;
            }

            if (pathCount >= 1) { isPathable = false; }
        }
    } 
}
