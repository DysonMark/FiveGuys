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
    [SerializeField] private Rigidbody _rb;

    private float sR;
    private float lifetimeStore;

    // Start is called before the first frame update
    void Start()
    {
        lifetimeStore = lifetime;
        insideWire = false;
        sR = spawnRate;
        _rb.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0.4f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        _rb.MoveRotation(Quaternion.Euler(0f, 0f, 90f));
        //Vector3 pos = transform.position;
        //pos.x += speed * Time.deltaTime;
        //transform.position = pos;



        if (insideWire)
        {
            //do nothing
            //or set the value to it
            lifetime = lifetimeStore;
        }
        else
        {
            lifetime -= Time.deltaTime;
        }

        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }

        sR -= Time.deltaTime;

        if (sR <= 0f)
        {
            sR = spawnRate;
            GameObject test = Instantiate(electricOrbs, transform.position, Quaternion.Euler(0f, 0f, -90f));
            //Instantiate(electricOrbs, transform.position, Quaternion.Euler(0f, 0f, -90f));
            var _t = test.GetComponent<Rigidbody>();
            _t.MoveRotation(Quaternion.Euler(0f, 0f, 90f));
            GameObject test2 = Instantiate(electricOrbs, transform.position, Quaternion.Euler(0f, 0f, 90f));
            var _t2 = test2.GetComponent<Rigidbody>();
            _t2.MoveRotation(Quaternion.Euler(0f, 0f, -90f));
        }

        

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
        
        //if the collided object is a turnerL or turnerR
        //turn it in that direction
        if (other.CompareTag("TurnerL"))
        {
            transform.Rotate(0, 0, 90f, Space.Self);
            Debug.Log("turning left");
        }
        if (other.CompareTag("TurnerR"))
        {
            transform.Rotate(0, 0, 90f, Space.Self);
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
