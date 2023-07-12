using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItemInCanvas : MonoBehaviour
{
    public int speed = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentOffsetMax = this.GetComponent<RectTransform>().offsetMax;
        Vector2 currentOffsetMin = this.GetComponent<RectTransform>().offsetMin;
        this.GetComponent<RectTransform>().offsetMax = new Vector2(currentOffsetMax.x - 1 * speed, currentOffsetMax.y);
        this.GetComponent<RectTransform>().offsetMin = new Vector2(currentOffsetMin.x - 1 * speed, currentOffsetMin.y);


        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            bool insideGoodTapRegion = RectTransformExtensions.Overlaps(this.GetComponent<RectTransform>(),
                                       ScrollingItemManager.Instance.checkRectangle);
            if (insideGoodTapRegion)
            {
                Debug.Log("overlapped!!!");
                Destroy(this.transform.gameObject);
                ScrollingItemManager.Instance.GenerateItem();
            }
        }
        bool insideDestroyRegion = RectTransformExtensions.Overlaps(this.GetComponent<RectTransform>(),
                                       ScrollingItemManager.Instance.destroyingRectangle);
        if (insideDestroyRegion)
        {
            Destroy(this.transform.gameObject);
            ScrollingItemManager.Instance.GenerateItem();
        }
    }
}
public static class RectTransformExtensions
{
    public static bool Overlaps(this RectTransform a, RectTransform b)
    {
        return a.WorldRect().Overlaps(b.WorldRect());
    }
    public static bool Overlaps(this RectTransform a, RectTransform b, bool allowInverse)
    {
        return a.WorldRect().Overlaps(b.WorldRect(), allowInverse);
    }

    public static Rect WorldRect(this RectTransform rectTransform)
    {
        Vector2 sizeDelta = rectTransform.sizeDelta;
        float rectTransformWidth = sizeDelta.x * rectTransform.lossyScale.x;
        float rectTransformHeight = sizeDelta.y * rectTransform.lossyScale.y;
        Vector3 position = rectTransform.position;
        return new Rect(position.x - rectTransformWidth / 2f, position.y - rectTransformHeight / 2f, rectTransformWidth, rectTransformHeight);
    }
}