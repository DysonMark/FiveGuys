using Unity.Mathematics;
using UnityEngine;

namespace Leonardo.Planks
{
    public class DestroyPlank : MonoBehaviour
    {
        [SerializeField] private GameObject woodParticleEffectPrefab;
        
        private GameObject currentWoodParticles;
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Plank")
            {
                GameObject particleEffect =
                    Instantiate(woodParticleEffectPrefab, transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                Destroy(particleEffect, 0.5f);
            }
            
        }
    }
}