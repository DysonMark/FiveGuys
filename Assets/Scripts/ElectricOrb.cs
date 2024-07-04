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
    [SerializeField] private Vector3 location;
    [SerializeField] private float distance;
    //[SerializeField] private Transform location;

    private float sR;

    // Start is called before the first frame update
    void Start()
    {
        insideWire = false;
        sR = spawnRate;
        location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Mathf.Abs(Mathf.Abs(transform.position.magnitude) - Mathf.Abs(location.magnitude)));

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

        //sR -= Time.deltaTime;  //do it magnitude based

        //if (sR <= 0)
        //{
        //    sR = spawnRate;
        //    Instantiate(electricOrbs, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
        //    Instantiate(electricOrbs, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90f));
        //}

        if (Mathf.Abs(Mathf.Abs(transform.position.magnitude) - Mathf.Abs(location.magnitude)) >= distance)
        {
            location = transform.position;
            Instantiate(electricOrbs, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
            Instantiate(electricOrbs, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90f));
            Debug.Log("that happened");

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
            Debug.Log("found wire");
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
        {
            insideWire = false;
            Debug.Log("exit wire");
        }
    }

}
