using Kandooz.ScriptableSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.FiveGuys.LightMoth
{
    public class Moth : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private JW_Vect3Variable lightPoint;
        [SerializeField] private float moveSpeed = 0.1f;
        [SerializeField] private Rigidbody rb;

        private void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, lightPoint.Value, moveSpeed);
        }
    } 
}
