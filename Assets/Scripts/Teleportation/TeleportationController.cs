using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Kandooz.ScriptableSystem;

namespace JW.FiveGuys.Teleportation
{
    /// <summary>
    /// Author: JW
    /// Attaches to the CameraRig game object and will be responsible for teleporting to specified locations
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
        [SerializeField] private KeyCode teleportKey = KeyCode.G; // For keyboard debugging

        public bool isPlayerTeleporting = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(Input.GetAxis("XRI_Left_Trigger"));

            if (Input.GetAxis("XRI_Left_Trigger") >=1 || Input.GetKeyDown(teleportKey)){
                isAiming = true;
                //Debug.Log("Aim Start");
                onAimStart.Raise();
            }
            else if (Input.GetAxis("XRI_Left_Trigger") <= 0 && isAiming && !Input.GetKey(teleportKey))
            {
                //Debug.Log("Aim Stop");
                isAiming = false;

                if (telePoint != null) // Teleport to the selected telePoint if there is one
                {
                    currentPoint.SetActive(true); // Activate the point we starrted on
                    TeleportationEventsHandler teleFrom = currentPoint.GetComponent<TeleportationEventsHandler>();
                    if (teleFrom != null) { teleFrom.OnTeleportFrom.Invoke(); }
                    //Debug.Log("TeleFrom");
                    transform.position = telePoint.transform.position; // Move our position to the new point
                    currentPoint = telePoint; // Update our point
                    TeleportationEventsHandler teleTo = currentPoint.GetComponent<TeleportationEventsHandler>();
                    if (teleTo != null) { teleTo.OnTeleportTo.Invoke(); }
                    //Debug.Log("TeleTo");
                    currentPoint.SetActive(false); // Disable the point we are now standing on
                    isPlayerTeleporting = true;
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
                    //Debug.Log("Hit Something");
                    if (telePoint != null) // Teleport point has been set before
                    {
                        //Debug.Log("TelePoint is set");
                        if (hitInfo.transform.gameObject != telePoint) // We've hit a different teleport point, so update the preview and telePoint
                        {
                            //Debug.Log("Telepoint is different from set point");
                            if (preview != null) preview.Stop(); // Stop the previous point if it exists

                            // Invoke any events on hover end
                            TeleportationEventsHandler events = telePoint.GetComponent<TeleportationEventsHandler>();
                            if (events != null) events.OnHoverEnd.Invoke();
                            //Debug.Log("On Hover End");

                            telePoint = hitInfo.transform.gameObject; // Update to the new hit object

                            // Invoke any events on hover start
                            events = telePoint.GetComponent<TeleportationEventsHandler>();
                            if (events != null) events.OnHoverStart.Invoke();
                            //Debug.Log("On Hover Start");

                            preview = telePoint.GetComponentInChildren<ParticleSystem>(); // Update preview particle system
                        }

                        if (!preview.isPlaying) preview.Play(); // Play the preview particle system if it isn't already
                    }
                    else // Our first teleport point
                    {
                        //Debug.Log("Telepoint is not set");
                        telePoint = hitInfo.transform.gameObject; // Update telePoint

                        // Start playing the preview particle system
                        preview = telePoint.GetComponentInChildren<ParticleSystem>();
                        preview.Play();

                        // Invoke any events on hover start
                        TeleportationEventsHandler events = telePoint.GetComponent<TeleportationEventsHandler>();
                        if (events != null) events.OnHoverStart.Invoke();
                        //Debug.Log("On Hover Start");
                    }
                }
                else // We hit nothing
                {
                    //Debug.Log("We hit nothing");
                    if (telePoint != null)
                    {
                        //Debug.Log("We did have a telepoint set");
                        TeleportationEventsHandler hoverEnd = telePoint.GetComponent<TeleportationEventsHandler>();
                        if (hoverEnd != null) { hoverEnd.OnHoverEnd.Invoke(); }
                        //Debug.Log("On Hover End");
                        telePoint = null; // Reset telePoint
                    }

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
