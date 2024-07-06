using Kandooz.ScriptableSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

namespace JW.FiveGuys.Flow
{
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
            start,
            end
        }
        [Header("Pathways")]
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
        public TileType DefaultType
        {
            get { return defaultType; }
        }
        public int Varient
        {
            get { return varient;  }
            set { varient = value; }
        }
        public bool IsPathable { get { return isPathable; } }
        public int  PathCount  { get { return pathCount;  } }

        private void OnEnable()
        {
            // Set the default values for the tile so it can be reset later if needed
            SetDefaults();
        }

        public void TogglePath(Directions path, bool state)
        {
            type = TileType.ocupied;
            switch (path)
            {
                case Directions.up:
                    if (!uPath.activeSelf)
                    {
                        uPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case Directions.down:
                    if (!dPath.activeSelf)
                    {
                        dPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case Directions.left:
                    if (!lPath.activeSelf)
                    {
                        lPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case Directions.right:
                    if (!rPath.activeSelf)
                    {
                        rPath.SetActive(state);
                        pathCount++;
                    }
                    break;
                case Directions.middle:
                    mPath.SetActive(state);
                    break;
                default:
                    break;
            }

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
            type = defaultType;
            varient = defaultVarient;

            uPath.SetActive(uDefault);
            dPath.SetActive(dDefault);
            lPath.SetActive(lDefault);
            rPath.SetActive(rDefault);
            mPath.SetActive(mDefault);

            isPathable = defaultPathable;
            pathCount = defaultPathCount;
        }

        public void SetDefaults()
        {
            // The tile's type at the start
            type = defaultType;
            // Pathway states at the start
            uDefault = uPath.activeSelf;
            dDefault = dPath.activeSelf;
            lDefault = lPath.activeSelf;
            rDefault = rPath.activeSelf;
            mDefault = mPath.activeSelf;
            defaultPathable = isPathable;
            defaultPathCount = pathCount;
            // The tile's varient
            defaultVarient = varient;
        }
    } 
}
