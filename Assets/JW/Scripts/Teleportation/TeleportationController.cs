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
    /// [] Make teleport points have a cylinder object that gets enabled when you start aiming, then disabled when not
    /// </summary>
    public class TeleportationController : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private GameObject head;
        [SerializeField] private Vector3 headOffset = new Vector3(0, 0.7f, 0);
        [SerializeField] private float maxDistance = 25f;
        [SerializeField] private bool isAiming = false;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private LayerMask teleportLayer;

        [Header("Previews")]
        [SerializeField] private GameObject telePoint;
        [SerializeField] private ParticleSystem preview;
        [SerializeField] private GameEvent onAimStart;
        [SerializeField] private GameEvent onAimStop;

        [Header("Debugging")]
        [SerializeField] private KeyCode teleportKey = KeyCode.G;

        // Start is called before the first frame update
        void Start()
        {
            lineRenderer.SetPosition(0, head.transform.position - headOffset);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(teleportKey)){
                isAiming = true;

                lineRenderer.SetPosition(0, head.transform.position);
                lineRenderer.SetPosition(0, head.transform.position - headOffset);

                onAimStart.Raise();
            }
            if (Input.GetKeyUp(teleportKey)){
                isAiming = false;

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

                lineRenderer.SetPosition(1, (head.transform.position - headOffset) + (head.transform.forward * maxDistance));

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
