using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.FiveGuys.Dyson.SetupStory
{
    public class ChangeText : MonoBehaviour
    {
        private TMP_Text textMesh;

        private Mesh mesh;

        private Vector3[] vertices;

        // Start is called before the first frame update
        void Start()
        {
            textMesh = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            TextEffect();
        }

        void TextEffect()
        {
            textMesh.ForceMeshUpdate();
            mesh = textMesh.mesh;
            vertices = mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 offset = Wobble(Time.time + i);
                vertices[i] = vertices[i] + offset;
            }

            mesh.vertices = vertices;
            textMesh.canvasRenderer.SetMesh(mesh);   
        }

    Vector2 Wobble(float time)
        {
            return new Vector2(Mathf.Sin(time * 3.3f), Mathf.Cos(time * 1.8f));
        }
        
    }
}
