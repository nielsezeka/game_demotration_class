using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rigidbody spaceShip;
    public static GameController Instance { get; private set; }
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
   
    private void FixedUpdate()
    {
        spaceShip.rotation = Quaternion.LookRotation(spaceShip.velocity);
    }
    internal static void MoveSpaceShip(Vector3 input)
    {
        GameController.Instance.spaceShip.velocity = input;
    }
}
