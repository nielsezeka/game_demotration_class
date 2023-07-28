using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSwithMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject customSkinMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenCustomSKin()
    {
        mainMenu.SetActive(false);
        customSkinMenu.SetActive(true);
    }
}
