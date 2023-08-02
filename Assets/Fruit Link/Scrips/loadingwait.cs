using UnityEngine;
using System.Collections;

public class loadingwait : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LoadLevelByFade());
    }

    IEnumerator LoadLevelByFade()
    {
        yield return new WaitForSeconds(3.6f);
        float fadeTime = GameObject.Find("ScaleScreen").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        Application.LoadLevel("welcome");
    }

}
