using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject prefabFire;
    public GameObject gunPostion;
    public GameObject currentCharacter;
    ForceMode mode = ForceMode.Impulse;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey("a"))
        {
            currentCharacter.GetComponent<Rigidbody>().AddForce(new Vector3(-speed, 0, 0), mode);
        }
        if (Input.GetKey("d"))
        {
            currentCharacter.GetComponent<Rigidbody>().AddForce(new Vector3(speed, 0, 0), mode);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }
    }
    public void Fire()
    {
        GameObject newFire = Instantiate(prefabFire);
        newFire.transform.position = gunPostion.transform.position;
    }
}
