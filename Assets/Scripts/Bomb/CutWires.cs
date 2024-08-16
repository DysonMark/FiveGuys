using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SAE.FiveGuys.Bomb
{
    public class CutWires : MonoBehaviour
    {
        [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
        private Mesh mesh;
        [SerializeField] private List<string> finisheditems = new();
        public DefuseTheBomb pass;
        [SerializeField] private GameObject axe;
        public CheckColliders redColliderCheck;
        public CheckColliders yellowColliderCheck;
        public CheckColliders blueColliderCheckOne;
        public CheckColliders blueColliderCheckTwo;
        public CheckColliders blueColliderCheckThree;
        public CheckColliders blueColliderCheckFour;
        public CheckColliders greenColliderCheckOne;
        public CheckColliders greenColliderCheckTwo;
        public CheckColliders greenColliderCheckThree;
        [SerializeField] private GameObject redWire;
        [SerializeField] private GameObject yellowWire;
        [SerializeField] private GameObject blueWireOne;
        [SerializeField] private GameObject blueWireTwo;
        [SerializeField] private GameObject blueWireThree;
        [SerializeField] private GameObject blueWireFour;
        [SerializeField] private GameObject greenWireOne;
        [SerializeField] private GameObject greenWireTwo;
        [SerializeField] private GameObject greenWireThree;
        
        // Start is called before the first frame update
        void Start()
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        void Update()
        {
           CutEachWires();
        }

        public void CutEachWires()
        {
            if (redColliderCheck.cutThisWire == true && redColliderCheck.gameObject.name == "Red_Wire_1")
            {
                finisheditems.Add("RedWire");
                pass.RedWire();
                skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
            }

            if (yellowColliderCheck.cutThisWire == true && yellowColliderCheck.gameObject.name == "Yellow_Wire_1")
            {
                finisheditems.Add("YellowWire");
                pass.YellowWire();
                skinnedMeshRenderer.SetBlendShapeWeight(3, 100);
            }

            if (blueColliderCheckOne.cutThisWire == true && blueColliderCheckOne.gameObject.name == "Blue_Wire_1" ||
                blueColliderCheckTwo.cutThisWire == true && blueColliderCheckTwo.gameObject.name == "Blue_Wire_2" ||
                blueColliderCheckThree.cutThisWire == true && blueColliderCheckThree.gameObject.name == "Blue_Wire_3" ||
                blueColliderCheckFour.cutThisWire == true && blueColliderCheckFour.gameObject.name == "Blue_Wire_4")
            {
                finisheditems.Add("BlueWire");
                pass.BlueWire();
                skinnedMeshRenderer.SetBlendShapeWeight(1, 100);
            }

            if (greenColliderCheckOne.cutThisWire == true && greenColliderCheckOne.gameObject.name == "Green_Wire" ||
                greenColliderCheckTwo.cutThisWire == true && greenColliderCheckTwo.gameObject.name == "Green_Wire_3" ||
                greenColliderCheckThree.cutThisWire == true &&
                greenColliderCheckThree.gameObject.name == "Green_Wire_4")
            {
                finisheditems.Add("GreenWire");
                pass.GreenWire();
                skinnedMeshRenderer.SetBlendShapeWeight(2, 100);
            }
        }
    }
}