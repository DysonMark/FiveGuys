using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SAE.FiveGuys.Bomb
{
    public class CutWires : MonoBehaviour
    {
        private SkinnedMeshRenderer skinnedMeshRenderer;
        private Mesh mesh;
        [SerializeField] private List<string> finisheditems = new();
        public DefuseTheBomb pass;
        //[SerializeField] private GameObject axe;
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
        [SerializeField] private GameObject bomb;

        // Timer 
        float timer = 0f;
        [SerializeField] float frequency = 0.1f;

        // Start is called before the first frame update
        void Start()
        {
            bomb = gameObject;
            skinnedMeshRenderer = bomb.GetComponent<SkinnedMeshRenderer>();
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= frequency)
            {
                CutEachWires();
                timer = 0f;
            }
        }

        public void CutEachWires()
        {
            if (redColliderCheck.cutThisWire == true && redColliderCheck.gameObject.name == "Red_Wire_1")
            {
                if (!finisheditems.Contains("RedWire"))
                {
                    finisheditems.Add("RedWire");
                    pass.CutRedWire();
                    skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
                }
            }

            if (yellowColliderCheck.cutThisWire == true && yellowColliderCheck.gameObject.name == "Yellow_Wire_1")
            {
                if (!finisheditems.Contains("YellowWire"))
                {
                    finisheditems.Add("YellowWire");
                    pass.CutYellowWire();
                    skinnedMeshRenderer.SetBlendShapeWeight(3, 100);
                }
            }

            if (blueColliderCheckOne.cutThisWire == true && blueColliderCheckOne.gameObject.name == "Blue_Wire_1" ||
                blueColliderCheckTwo.cutThisWire == true && blueColliderCheckTwo.gameObject.name == "Blue_Wire_2" ||
                blueColliderCheckThree.cutThisWire == true && blueColliderCheckThree.gameObject.name == "Blue_Wire_3" ||
                blueColliderCheckFour.cutThisWire == true && blueColliderCheckFour.gameObject.name == "Blue_Wire_4")
            {
                if (!finisheditems.Contains("BlueWire"))
                {
                    finisheditems.Add("BlueWire");
                    pass.CutBlueWire();
                    skinnedMeshRenderer.SetBlendShapeWeight(1, 100);
                }

            }

            if (greenColliderCheckOne.cutThisWire == true && greenColliderCheckOne.gameObject.name == "Green_Wire" ||
                greenColliderCheckTwo.cutThisWire == true && greenColliderCheckTwo.gameObject.name == "Green_Wire_3" ||
                greenColliderCheckThree.cutThisWire == true &&
                greenColliderCheckThree.gameObject.name == "Green_Wire_4")
            {
                if (!finisheditems.Contains("GreenWire"))
                {
                    finisheditems.Add("GreenWire");
                    pass.CutGreenWire();
                    skinnedMeshRenderer.SetBlendShapeWeight(2, 100);
                }
            }
        }
    }
}
