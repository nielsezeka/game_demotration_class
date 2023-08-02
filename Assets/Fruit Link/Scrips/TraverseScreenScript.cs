using UnityEngine;
using System.Collections;

public class TraverseScreenScript : MonoBehaviour
{

    public static TraverseScreenScript traverScreen;
    public static bool isMusic;

    void Awake()
    {
        if (traverScreen == null)
        {
            DontDestroyOnLoad(gameObject);
            traverScreen = this;
        }
        else if (traverScreen != this)
        {
            Destroy(gameObject);
        }
    }

}