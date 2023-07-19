using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollingItem : MonoBehaviour
{
    public GameObject scrollRegion;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< SkinManager.Instance.supportedSkin.Length; i++)
        {
            GameObject item = Instantiate(itemPrefab);
            item.transform.SetParent(scrollRegion.transform);
            item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            item.GetComponent<SkinSelection>().index = i;
            item.GetComponent<SkinSelection>().SetTextName(SkinManager.Instance.supportedSkin[i].nameOfItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
