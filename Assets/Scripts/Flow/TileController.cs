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

    private void OnEnable()
    {
        scriptableTile.Value = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        scriptableTile.Value = gameObject;
        tilePressed.Raise();
    }
}
