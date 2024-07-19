using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JW.FiveGuys.Teleportation
{
    /// <summary>
    /// Author: JW
    /// Attaches to the teleport point GameObject and has the respective event called when it's condition is met (handle by the TeleportationController)
    /// </summary>
    public class TeleportationEventsHandler : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent OnHoverStart;
        public UnityEvent OnHoverEnd;
        public UnityEvent OnTeleportTo;
        public UnityEvent OnTeleportFrom;
    } 
}
