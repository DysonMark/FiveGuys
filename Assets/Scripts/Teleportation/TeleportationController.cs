using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Kandooz.ScriptableSystem;

namespace JW.FiveGuys.Core
{
    /// <summary>
    /// Author: JW
    /// Attaches to the CameraRig game object and will be responsible for teleporting to specified locations
    /// 
    /// TODO:
    /// [x] Make teleport points have a cylinder object that gets enabled when you start aiming, then disabled when not
    /// </summary>
    public class TeleportationController : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private GameObject head;
        [SerializeField] private Vector3 headOffset = new Vector3(0, 0.7f, 0);
        [SerializeField] private float maxDistance = 25f;
        [SerializeField] private bool isAiming = false;
        [SerializeField] private LayerMask teleportLayer;

        [Header("Previews")]
        [SerializeField] private ParticleSystem preview;
        [SerializeField] private GameEvent onAimStart;
        [SerializeField] private GameEvent onAimStop;

        [Header("Teleport Points")]
        [SerializeField] private GameObject telePoint; // The one we are aiming at
        [SerializeField] private GameObject currentPoint; // The one we are standing on

        [Header("Debugging")]
        [SerializeField] private KeyCode teleportKey = KeyCode.G;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(teleportKey)){
                isAiming = true;

                onAimStart.Raise();
            }
            if (Input.GetKeyUp(teleportKey)){
                isAiming = false;

                if (telePoint != null) // Teleport to the selected telePoint if there is one
                {
                    currentPoint.SetActive(true); // Activate the point we starrted on
                    transform.position = telePoint.transform.position; // Move our position to the new point
                    currentPoint = telePoint; // Update our point
                    currentPoint.SetActive(false); // Disable the point we are now standing on
                }

                telePoint = null;
                if (preview != null)
                {
                    preview.Stop();
                    preview = null;
                }

                onAimStop.Raise();
            }

            if (isAiming)
            {
                // 1. Update LineRender
                // 2. Raycast for telepoints
                // 3. if raycast hit something
                //      if telePoint != null => 
                //        if hit object == telePoint => play particle system if not already playing
                //        el telePoint = hit object & play particle system
                //      el telePoint = hit object & play particle system

                var gazeHit = Physics.Raycast(head.transform.position - headOffset, head.transform.forward, out RaycastHit hitInfo, maxDistance, teleportLayer);
                if (gazeHit) // We hit something
                {
                    if (telePoint != null) // Teleport point has been set before
                    {
                        if (hitInfo.transform.gameObject != telePoint) // We've hit a different teleport point, so update the preview and telePoint
                        {
                            if (preview != null) preview.Stop(); // Stop the previous point if it exists

                            telePoint = hitInfo.transform.gameObject; // Update to the new hit object

                            preview = telePoint.GetComponentInChildren<ParticleSystem>(); // Update preview particle system
                        }

                        if (!preview.isPlaying) preview.Play(); // Play the preview particle system if it isn't already
                    }
                    else // Our first teleport point
                    {
                        telePoint = hitInfo.transform.gameObject; // Update telePoint

                        // Start playing the preview particle system
                        preview = telePoint.GetComponentInChildren<ParticleSystem>();
                        preview.Play();
                    }
                }
                else // We hit nothing
                {
                    telePoint = null; // Reset telePoint

                    if (preview != null) preview.Stop(); // Stop playing the preview particle system if there is still one
                    preview = null; // Reset preview particle system
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Debug.DrawRay(head.transform.position - headOffset, head.transform.forward, Color.red, maxDistance);

            if (isAiming)
            {
                Debug.DrawRay(head.transform.position - headOffset, head.transform.forward, Color.yellow, maxDistance);
            }
        }

    } 
}
