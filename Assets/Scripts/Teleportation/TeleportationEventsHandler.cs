using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportationEventsHandler : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnHoverStart;
    public UnityEvent OnHoverEnd;
    public UnityEvent OnTeleportTo;
    public UnityEvent OnTeleportFrom;
}
