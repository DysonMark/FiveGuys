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
            else if (Input.GetAxis("XRI_Left_Trigger") <= 0 && isAiming && !Input.GetKey(teleportKey)) // Stopped aiming
            {
                //Debug.Log("Aim Stop");
                isAiming = false;

                if (telePoint != null) // Teleport to the selected telePoint if there is one
                {
                    TeleportationEventsHandler teleFrom = currentPoint.GetComponent<TeleportationEventsHandler>();
                    if (teleFrom != null) { teleFrom.OnTeleportFrom.Invoke(); } // Invoke teleport from events
                    
                    transform.position = telePoint.transform.position; // Move our position to the new point
                    currentPoint = telePoint; // Update our point

                    TeleportationEventsHandler teleTo = currentPoint.GetComponent<TeleportationEventsHandler>();
                    if (teleTo != null) { teleTo.OnTeleportTo.Invoke(); } // Invoke teleport to events

                    isPlayerTeleporting = true;
                }

                telePoint = null; // I honestly don't remember why this is in here. It might be for clearing the tellepoint after going to a new one?

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
                    if (hitInfo.collider.tag == "Telepoint")
                    {
                        //Debug.Log("Hit Something");
                        if (telePoint != null) // Teleport point has been set before
                        {
                            //Debug.Log("TelePoint is set");
                            if (hitInfo.transform.gameObject != telePoint) // We've hit a different teleport point, so update the preview and telePoint
                            {
                                // Invoke any events on hover end
                                TeleportationEventsHandler events = telePoint.GetComponent<TeleportationEventsHandler>();
                                if (events != null) events.OnHoverEnd.Invoke();

                                telePoint = hitInfo.transform.gameObject; // Update to the new hit object

                                // Invoke any events on hover start
                                events = telePoint.GetComponent<TeleportationEventsHandler>();
                                if (events != null) events.OnHoverStart.Invoke();
                            }
                        }
                        else // Our first teleport point
                        {
                            //Debug.Log("Telepoint is not set");
                            telePoint = hitInfo.transform.gameObject; // Update telePoint

                            // Invoke any events on hover start
                            TeleportationEventsHandler events = telePoint.GetComponent<TeleportationEventsHandler>();
                            if (events != null) events.OnHoverStart.Invoke();
                        }
                    }
                    else
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

                        telePoint = null; // Same reseting of tellepoints as before maybe? idk at this point XD
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

                    telePoint = null; // Legit do not know why these are here but not removing them cuz that might break it
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
