using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.Events;

namespace SAE.FiveGuys.Bomb
{
    public class CheckColliders : MonoBehaviour
    {
        public bool cutThisWire = false;
        [SerializeField] private Vector3 point0;
        [SerializeField] private Vector3 point1;
        public float radius = 1.0f;
        public LayerMask layerMask;
        public Color capsuleColor = Color.red;
        public CutWires checkEvent;
        public UnityEvent onWireCut;

        private void Start()
        {
            //  checkEvent.onUse.AddListener(checkEvent.CutEachWires);
        }

        private void Update()
        {
            CutOverlapCapsule();
        }

        public void CutOverlapCapsule()
        {
            Collider[] hitColliders = Physics.OverlapCapsule(point0, point1, radius);

            foreach (Collider hitCollider in hitColliders)
            {
                Debug.Log(hitCollider.gameObject.name);
                if (hitCollider.gameObject.name == "Metal")
                {
                    cutThisWire = true;
                    //onWireCut.Invoke();
                    //checkEvent.onWireCut.Invoke();
                    //      checkEvent.onUse.Invoke();
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = capsuleColor;

            // Draw the two spheres at the ends of the capsule
            Gizmos.DrawWireSphere(point0, radius);
            Gizmos.DrawWireSphere(point1, radius);

            // Draw the connecting lines between the spheres to form the capsule
            DrawCapsuleLine(point0, point1, radius);
        }

        void DrawCapsuleLine(Vector3 p0, Vector3 p1, float r)
        {
            Vector3 up = (p1 - p0).normalized * r;

            // Draw lines from the edges of the spheres
            Gizmos.DrawLine(p0 + up, p1 + up);
            Gizmos.DrawLine(p0 - up, p1 - up);
            Gizmos.DrawLine(p0 + Vector3.right * r, p1 + Vector3.right * r);
            Gizmos.DrawLine(p0 - Vector3.right * r, p1 - Vector3.right * r);
            Gizmos.DrawLine(p0 + Vector3.forward * r, p1 + Vector3.forward * r);
            Gizmos.DrawLine(p0 - Vector3.forward * r, p1 - Vector3.forward * r);
        }
    }
}