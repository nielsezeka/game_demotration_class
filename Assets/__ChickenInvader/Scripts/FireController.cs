using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float speed = 1.0f;
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, -speed, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
