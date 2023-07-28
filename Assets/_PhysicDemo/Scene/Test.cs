using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float force = 100;
    float multiplier = 2;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(100,0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger" + other.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collison"+ collision.gameObject.name);
    }
}
