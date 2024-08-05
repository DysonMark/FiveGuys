using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{
    public class CutWires : MonoBehaviour
    {
        private SkinnedMeshRenderer skinnedMeshRenderer;
        public string blendShapeName;
        private Mesh mesh;
        public float blendShapeWeight;

        // Start is called before the first frame update
        void Start()
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            // blendShapeIndex = mesh.GetBlendShapeIndex(blendShapeName);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                skinnedMeshRenderer.SetBlendShapeWeight(1, 100);
                Debug.Log("Space pressed");
            }
        }
    }

}