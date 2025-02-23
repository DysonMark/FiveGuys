using Unity.Mathematics;
using UnityEngine;

namespace Leonardo.Planks
{
    public class DestroyPlank : MonoBehaviour
    {
        [SerializeField] private GameObject woodParticleEffectPrefab;
        
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Plank"))
            {
                Vector3 impactPoint = col.contacts[0].point;
                GameObject particleEffect = Instantiate(
                    woodParticleEffectPrefab, 
                    impactPoint, 
                    Quaternion.LookRotation(col.contacts[0].normal)
                );

                Destroy(col.gameObject);
                
                Destroy(particleEffect, 0.5f);
            }
        }
    }
}