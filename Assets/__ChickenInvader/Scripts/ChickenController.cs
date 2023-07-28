using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public GameObject prefabChicken;
    public float distance = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=-5;i<5; i++)
        {
           GameObject aChicken = Instantiate(prefabChicken);
            aChicken.transform.transform.position = new Vector3(distance * i, 4,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
