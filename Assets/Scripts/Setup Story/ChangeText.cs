using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.FiveGuys.Dyson.SetupStory
{
    /// <summary>
    /// Applies a dynamic wobble effect to the vertices of a TMP_Text component for animated text visuals.
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class ChangeText : MonoBehaviour
    {
        private TMP_Text textMesh;
        private Mesh mesh;
        private Vector3[] vertices;

        private void Awake()
        {
            textMesh = GetComponent<TMP_Text>();
            if (textMesh == null)
            {
                Debug.LogError("ChangeText: No TMP_Text component found on this GameObject.");
            }
        }

        private void Update()
        {
            ApplyWobbleEffect();
        }

        /// <summary>
        /// Updates the mesh vertices each frame to create a wobble animation.
        /// </summary>
        private void ApplyWobbleEffect()
        {
            if (textMesh == null) return;

            textMesh.ForceMeshUpdate();
            mesh = textMesh.mesh;
            vertices = mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 offset = GetWobbleOffset(Time.time + i);
                vertices[i] += offset;
            }

            mesh.vertices = vertices;
            textMesh.canvasRenderer.SetMesh(mesh);
        }

        /// <summary>
        /// Calculates a wobble offset for a given time and vertex index.
        /// </summary>
        private Vector3 GetWobbleOffset(float time)
        {
            float x = Mathf.Sin(time * 3.3f);
            float y = Mathf.Cos(time * 1.8f);
            return new Vector3(x, y, 0f);
        }
    }
}
