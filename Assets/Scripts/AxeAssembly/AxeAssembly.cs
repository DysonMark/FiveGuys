using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Leonardo.AxeAssembly
{
    public class AxeAssembly : MonoBehaviour
    {
        [SerializeField] private GameObject axeHandleGameObject; // The position in which the axe Handle is currently in.
        [SerializeField] private GameObject axeHeadGameObject; // The position in which the axe Head is currently in.
        [SerializeField] private GameObject axeGameObject; // The PreFab of the full Axe.
        [SerializeField] private Transform axeInstantiationPos; // Position in which the axe is going to be instantiated once the pieces are together.

        [SerializeField] private float axeSpawnDelay = 1.5f;

        [SerializeField] private GameObject particleEffects;
        
        private int piecesWithinRange;
        private bool axeWasInstantiated = false;

        private void Start()
        {
            particleEffects.SetActive(false);
        }

        private void Update()
        {
            CheckPiecesInRange();
            Debug.Log("Pieces within range:" + piecesWithinRange);
        }


        // Check the pieces in range of assembly.
        private void CheckPiecesInRange()
        {
            // If two pieces are in range, assemble the axe
            if(piecesWithinRange == 2)
            {
                StartAxeAssembly();
            }
        }
        // If the two pieces are "Socketed" in the Workstation, create the Axe GameObject
        private void StartAxeAssembly()
        {
            if (!axeWasInstantiated)
            {
                axeWasInstantiated = true;
                // Starts the assembling coroutine.
                StartCoroutine(InstantiateCompleteAxePrefab());
            }
        }

        IEnumerator InstantiateCompleteAxePrefab()
        {
            particleEffects.SetActive(true);
            yield return new WaitForSeconds(axeSpawnDelay);
            // Instantiates the full Axe.
            Destroy(axeHandleGameObject);
            Destroy(axeHeadGameObject);
            particleEffects.SetActive(false);
            Instantiate(axeGameObject, axeInstantiationPos);
        }
        
        // The "Pieces Within Range" counter goes UP each time a piece is within range.
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.name == "HeadMeshRenderer")
            {
                piecesWithinRange++;
            }
            if (other.transform.name == "HandleMeshRenderer")
            {
                piecesWithinRange++;
            }
        }

        // The "Pieces Within Range" counter goes DOWN each time a piece is within range.
        private void OnTriggerExit(Collider other)
        {
            if (other.transform.name == "HeadMeshRenderer")
            {
                piecesWithinRange--;
            }
            if (other.transform.name == "HandleMeshRenderer")
            {
                piecesWithinRange--;
            }
        }
    }
}