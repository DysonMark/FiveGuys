using Kandooz.ScriptableSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

namespace JW.FiveGuys.Flow
{
    /// <summary>
    /// Author: JW
    /// The script attached to the tile GameObject for the Flow puzzle
    /// </summary>
    public class TileController : MonoBehaviour
    {
        public enum Directions
        {
            up,
            down,
            left, 
            right,
            middle
        }
        public enum TileType
        {
            blank,
            ocupied,
            point
        }
        [Header("Pathways")]
        [SerializeField] private List<Material> materials;
        [SerializeField] private GameObject uPath;
        [SerializeField] private GameObject dPath;
        [SerializeField] private GameObject lPath;
        [SerializeField] private GameObject rPath;
        [SerializeField] private GameObject mPath;

        [Header("FlowController")]
        [SerializeField] private TileType type = TileType.blank;
        [SerializeField] private int varient = 0;
        [SerializeField] private bool isPathable = true;
        [SerializeField] private int pathCount = 0;

        [Header("Defaults")]
        [SerializeField] private bool defaultPathable;
        [SerializeField] private int defaultPathCount;
        [SerializeField] private TileType defaultType = TileType.blank;
        [SerializeField] private int defaultVarient = 0;
        [SerializeField] private bool uDefault = false;
        [SerializeField] private bool dDefault = false;
        [SerializeField] private bool lDefault = false;
        [SerializeField] private bool rDefault = false;
        [SerializeField] private bool mDefault = false;

        public TileType Type
        {
            get { return type;  }
            set { type = value; }
        }
        public int Varient
        {
            get { return varient;  }
            set { varient = value; }
        }
        public bool IsPathable { get { return isPathable; } }
        public int  PathCount  
        { 
            get { return pathCount ; } 
            set { pathCount = value; }
        }

        private void OnEnable()
        {
            // Set the default values for the tile so it can be reset later if needed
            SetDefaults();
        }

        /// <summary>
        /// Sets the given direction's GameObject to enabled to draw the path. Also set its material to the current varient and handles updating whether the tile is "pathable" or not
        /// </summary>
        /// <param name="path">The direction to draw in using the direction enum</param>
        /// <param name="state">Whether to enable or disable that direction's GameObject</param>
        public void TogglePath(Directions path, bool state)
        {
            type = TileType.ocupied;
            switch (path)
            {
                case Directions.up:
                    if (!uPath.activeSelf)
                    {
                        uPath.SetActive(state);
                        uPath.GetComponent<Renderer>().material = materials[varient];
                        pathCount++;
                    }
                    break;
                case Directions.down:
                    if (!dPath.activeSelf)
                    {
                        dPath.SetActive(state);
                        dPath.GetComponent<Renderer>().material = materials[varient];
                        pathCount++;
                    }
                    break;
                case Directions.left:
                    if (!lPath.activeSelf)
                    {
                        lPath.SetActive(state);
                        lPath.GetComponent<Renderer>().material = materials[varient];
                        pathCount++;
                    }
                    break;
                case Directions.right:
                    if (!rPath.activeSelf)
                    {
                        rPath.SetActive(state);
                        rPath.GetComponent<Renderer>().material = materials[varient];
                        pathCount++;
                    }
                    break;
                case Directions.middle:
                    mPath.SetActive(state);
                    mPath.GetComponent<Renderer>().material = materials[varient];
                    break;
                default:
                    break;
            }

            // Update the tile's pathable state if it is more than or equal to 1. A tile is considered full if it has more than 2 paths on it, but we can still draw a path when leaving a now "full" tile. Also makes it so we can easily set the correct state for "point" tiles to be full with only 1 connection, preventing different colors on the same tile
            if (pathCount >= 1) 
            { 
                isPathable = false;
            }
        }

        /// <summary>
        /// Resets the tile to the state to what it was initialy set to
        /// </summary>
        public void SetToDefaults()
        {
            // Type and varient
            type = defaultType;
            varient = defaultVarient;

            // Path GameObjects
            uPath.SetActive(uDefault);
            dPath.SetActive(dDefault);
            lPath.SetActive(lDefault);
            rPath.SetActive(rDefault);
            mPath.SetActive(mDefault);

            // Tile's color
            uPath.GetComponent<Renderer>().material = materials[varient];
            dPath.GetComponent<Renderer>().material = materials[varient];
            lPath.GetComponent<Renderer>().material = materials[varient];
            rPath.GetComponent<Renderer>().material = materials[varient];
            mPath.GetComponent<Renderer>().material = materials[varient];

            // Pathable state and path count
            isPathable = defaultPathable;
            pathCount = defaultPathCount;
        }

        /// <summary>
        /// Sets the default values to what that variable's value is currently
        /// </summary>
        public void SetDefaults()
        {
            // The tile's type at the start
            defaultType = type;
            defaultVarient = varient;
            // Pathway states and color at the start
            defaultPathable = isPathable;
            defaultPathCount = pathCount;
            uDefault = uPath.activeSelf;
            dDefault = dPath.activeSelf;
            lDefault = lPath.activeSelf;
            rDefault = rPath.activeSelf;
            mDefault = mPath.activeSelf;
            uPath.GetComponent<Renderer>().material = materials[varient];
            dPath.GetComponent<Renderer>().material = materials[varient];
            lPath.GetComponent<Renderer>().material = materials[varient];
            rPath.GetComponent<Renderer>().material = materials[varient];
            mPath.GetComponent<Renderer>().material = materials[varient];
        }
    } 
}
