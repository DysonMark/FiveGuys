using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireButton : MonoBehaviour
{

    [SerializeField] private GameObject electricOrb;
    [SerializeField] private GameObject location;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
            //Instantiate(electricOrb, location.transform.position, Quaternion.identity);
        
    }

    public void SpawnOrb()
    {

        Instantiate(electricOrb, location.transform.position, Quaternion.identity);

    }

}
