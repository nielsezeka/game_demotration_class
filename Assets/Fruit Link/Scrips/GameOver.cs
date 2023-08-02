using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    public GameObject TimeBar;
    public GameObject GameOverUI;
    public GameObject WinUI;
    bool gameover = false;
    float cdtime = 0;
    bool ms = false;
    public GameObject sound;
    float delaytime = 2.7f;
    public Transform timebarend;
    float dist;

    void Start()
    {
        cdtime = GlobalValues.LimitTime;
        GameOverUI.SetActive(false);
        gameover = false;
        dist = TimeBar.transform.localPosition.x - timebarend.localPosition.x;

        StartCoroutine(startDelay());
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(delaytime);
        GlobalValues.cdstart = true;
    }


    void Update()
    {
        if (!gameover && !GlobalValues.isPause && GlobalValues.cdstart)
            timeCountdown();
    }
    /// <summary>
    /// countdown game time / scale time  bar
    /// </summary>
    void timeCountdown()
    {
        if (!gameover)
        {
            TimeBar.transform.localScale -= new Vector3((1f / cdtime) * Time.deltaTime, 0, 0);
            TimeBar.transform.localPosition -= new Vector3((dist / cdtime) * Time.deltaTime, 0, 0);
            GlobalValues.Countdown -= Time.deltaTime;
        }
        if (GlobalValues.Countdown < 0)
        {

            if (GlobalValues.Score < GlobalValues.TargetScore)
            {
                GlobalValues.isPause = true;
                GameOverUI.SetActive(true);

                if (!ms && TraverseScreenScript.isMusic)
                {
                    Destroy(Instantiate(sound), 2.7f);
                    ms = true;
                }

            }
            else
            {
                WinUI.SetActive(true);

                if (GlobalValues.Score < GlobalValues.TargetScore + 50)
                    GlobalValues.Stars = 1;
                else if (GlobalValues.TargetScore + 50 <= GlobalValues.Score && GlobalValues.Score < GlobalValues.TargetScore + 100)
                    GlobalValues.Stars = 2;
                else
                    GlobalValues.Stars = 3;
            }
            gameover = true;
        }
    }
}
