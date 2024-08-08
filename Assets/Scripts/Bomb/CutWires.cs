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
        [SerializeField] private List<string> finisheditems = new();
        public DefuseTheBomb pass;
        [SerializeField] private GameObject axe;

        // Start is called before the first frame update
        void Start()
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "RedWire" && !finisheditems.Contains(("RedWire")))
            {
                finisheditems.Add("RedWire");
                pass.RedWire();
                skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
            }

            if (other.gameObject.tag == "YellowWire" && !finisheditems.Contains("YellowWire"))
            {
                finisheditems.Add("YellowWire");
                pass.YellowWire();
                skinnedMeshRenderer.SetBlendShapeWeight(3, 100);
            }

            if (other.gameObject.tag == "BlueWire" && !finisheditems.Contains("BlueWire"))
            {
                finisheditems.Add("BlueWire");
                pass.BlueWire();
                skinnedMeshRenderer.SetBlendShapeWeight(1, 100);
            }

            if (other.gameObject.tag == "GreenWire" && !finisheditems.Contains("GreenWire"))
            {
                finisheditems.Add("GreenWire");
                pass.GreenWire();
                skinnedMeshRenderer.SetBlendShapeWeight(2, 100);
            }
        }
    }

}