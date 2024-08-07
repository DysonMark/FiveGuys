using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{
    public class CutWires : MonoBehaviour
    {
        [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
        private Mesh mesh;
        public DefuseTheBomb pass;
        [SerializeField] private GameObject axe;
        public bool isAxe = false;

        // Start is called before the first frame update
        void Start()
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void CutColorWires()
        {
            if (pass.redPass == true)
                skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
            if (pass.bluePass == true)
                skinnedMeshRenderer.SetBlendShapeWeight(1, 100);
            if (pass.greenPass == true)
                skinnedMeshRenderer.SetBlendShapeWeight(2, 100);
            if (pass.yellowPass == true)
                skinnedMeshRenderer.SetBlendShapeWeight(3, 100);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "RedWire")
            {
                //isAxe = true;
                pass.RedWire();
                CutColorWires();
                Debug.Log("ENTER redWire");
            }

            if (other.gameObject.tag == "YellowWire")
            {
                pass.YellowWire();
                CutColorWires();
                Debug.Log("ENTER yellowWire");
            }

            if (other.gameObject.tag == "BlueWire")
            {
                pass.BlueWire();
                CutColorWires();
                Debug.Log("ENTER blueWire");
            }

            if (other.gameObject.tag == "GreenWire")
            {
                pass.GreenWire();
                CutColorWires();
                Debug.Log("ENTER greenWire");
            }
        }
    }

}