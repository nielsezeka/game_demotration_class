using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCustomCloth : MonoBehaviour
{
    public int indentifier;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowOrHidePart()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
