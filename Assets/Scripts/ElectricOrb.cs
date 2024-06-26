using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrb : MonoBehaviour
{

    [SerializeField] private float lifetime;
    [SerializeField] private bool insideWire;
    [SerializeField] private GameObject electricOrbs;
    [SerializeField] private float spawnRate;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        insideWire = false;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

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
            Destroy(gameObject);
        }

        //every quarter of a second spawn electric orbs on the left and right of it
        //also it goes in the positive direction of where it was instantiated
        //relative to the power generator

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("found something");
        if (other.CompareTag("Wire"))
        {
            insideWire = true;
        }
        else
        {
            
            insideWire = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit something");
        if (other.CompareTag("Wire"))
        insideWire = false;
    }

}
