using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingetonTestManager : MonoBehaviour
{
    public DemoManageCharacter xxx;
    public GameObject cloth;
    //singleton 
    public static SingetonTestManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
