using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemobossBehavior : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public int heath;
    public int currentHeath;
    public GameObject fxDie;
    void Start()
    {
        currentHeath = heath;
         slider.maxValue = heath;
        // timer
    }
    // Update is called once per frame
    void Update()
    {
        
       slider.value = currentHeath;
    }
    private void FixedUpdate()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("boss collition");
        currentHeath -= 1;
        if (currentHeath==0)
        {
            fxDie.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("boss triggrt");
    }
    void FireToPlayer()
    {
       // Instantiate(prefab)
    }
}
