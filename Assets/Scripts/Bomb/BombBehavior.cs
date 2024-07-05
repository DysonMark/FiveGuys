using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kandooz.ScriptableSystem;

namespace SAE.FiveGuys.Bomb
{ 
    public class BombBehavior : MonoBehaviour
    {
        public GameObject bomb;
        [SerializeField] private IntVariable counting;
        // Start is called before the first frame update
        void Start()
        {
            bomb = GameObject.Find("Bomb");
            Invoke("ChangeBombColor", counting.Value);
        }

        void ChangeBombColor()
        {
            Debug.Log("Im here");
            var bombRenderer = bomb.GetComponent<Renderer>();
            bombRenderer.material.SetColor("_BaseColor", Color.red);
            Debug.Log("Explosion");
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
