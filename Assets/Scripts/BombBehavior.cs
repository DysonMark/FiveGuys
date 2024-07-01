using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.FiveGuys.Bomb
{ 
    public class BombBehavior : MonoBehaviour
    {
        public GameObject bomb;
        // Start is called before the first frame update
        void Start()
        {
            bomb = GameObject.Find("Bomb");
            Invoke("ChangeBombColor", 3);
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
