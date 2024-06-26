using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrb : MonoBehaviour
{

    [SerializeField] private float lifetime;
    [SerializeField] private bool insideWire;
    [SerializeField] private GameObject electricOrbs;

    // Start is called before the first frame update
    void Start()
    {
        insideWire = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (insideWire)
        {
            //do nothing
        }
        else
        {
            lifetime -= Time.deltaTime;
        }

        if (lifetime <= 0f)
        {
            Destroy(this);
        }

        //every quarter of a second spawn electric orbs on the left and right of it
        //also it goes in the positive direction of where it was instantiated
        //relative to the power generator

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wire"))
        {
            //do nothing
            //or turn the lifetime bool to false
        }
        else
        {
            //deduct lifetime
            insideWire = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wire"))
        {
            //deduct lifetime
            insideWire = false;
        }
    }

}
