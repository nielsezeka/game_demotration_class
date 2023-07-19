using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SkinManager : MonoBehaviour
{
    public SkinPart[] supportedSkin;
    // Start is called before the first frame update
    public static SkinManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public SkinPart GetPartID(int index)
    {
        return Array.Find(supportedSkin, p => p.idItem == index);
    }

    // Update is called once per frame
    public void ShowHidePart(int index)
    {
        GameObject thePart = GetPartID(index).gameObject;
        if(thePart.activeSelf)
        {
            GetPartID(index).gameObject.SetActive(false);
        } else
        {
            GetPartID(index).gameObject.SetActive(true);
        }
       
    }
}
