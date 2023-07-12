using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingItemManager : MonoBehaviour
{
    public GameObject prefabItem;
    public RectTransform checkRectangle;
    public RectTransform destroyingRectangle;
    public static ScrollingItemManager Instance { get; private set; }
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
        GenerateItem();
    }
    public void GenerateItem()
    {
        GameObject item = Instantiate(prefabItem);
        item.GetComponent<MovingItemInCanvas>().speed = Random.Range(4, 15);
        item.transform.SetParent(this.gameObject.transform);
        item.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        item.GetComponent<RectTransform>().offsetMin = new Vector2(-300, 0);
        item.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
