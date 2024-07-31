using Kandooz.ScriptableSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.FiveGuys.LightMoth
{
    /// <summary>
    /// Author: JW
    /// Moves towards a Vector3 point at a given speed
    /// </summary>
    public class Moth : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private AdvancedVector3 lightPoint;
        [SerializeField] private float moveSpeed = 0.1f;
        [SerializeField] private Rigidbody rb;

        private void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.velocity = (lightPoint.Value - transform.position).normalized * moveSpeed;
        }
    } 
}
