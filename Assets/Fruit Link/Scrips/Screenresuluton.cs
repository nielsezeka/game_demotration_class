using UnityEngine;
using System.Collections;

public class Screenresuluton : MonoBehaviour
{

    public GameObject cube;
    void Start()
    {
        #if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8
            float s = (((float)Screen.height / (float)Screen.width) - (800f / 480f));

            if (Mathf.Abs(s) > 0.1f)
                s = s * 0.8f;
            cube.transform.localScale -= new Vector3(s, 0, 0);
        #endif
    }

}
