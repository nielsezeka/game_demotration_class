using UnityEngine;
using System.Collections;

public class NumberShow : MonoBehaviour
{


    // Use this for initialization
    public SpriteRenderer[] level;
    public Sprite[] levelrender;
    public SpriteRenderer[] targerScore;
    public Sprite[] targerScoreRender;
    public SpriteRenderer[] scoreobj;

    void Start()
    {
        lvshow();
        targetscorehow();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreShow(GlobalValues.Score);

    }
    void lvshow()
    {
        float posx = -2.147083f;
        if (GlobalValues.level < 10)
        {
            level[0].sprite = levelrender[GlobalValues.level];
            posx = -2.3f;
        }
        else
        {
            level[0].sprite = levelrender[GlobalValues.level % 10];
            level[1].sprite = levelrender[GlobalValues.level / 10];
        }
        Vector3 vttemp = new Vector3(posx, level[0].gameObject.transform.position.y, level[0].gameObject.transform.position.z);
        level[0].gameObject.transform.position = vttemp;
    }

    void ScoreShow(int score)
    {
        int chucnghin_ = 0;
        int nghin_ = 0;
        int tram_ = 0;
        int chuc_ = 0;
        int dv_ = 0;
        int temp_ = 0;
        chucnghin_ = score / 10000;
        temp_ = score % 10000;
        nghin_ = temp_ / 1000;
        temp_ = temp_ % 1000;
        tram_ = temp_ / 100;
        temp_ = temp_ % 100;
        chuc_ = temp_ / 10;
        temp_ = temp_ % 10;
        dv_ = temp_;
        scoreobj[0].sprite = levelrender[dv_];
        scoreobj[1].sprite = levelrender[chuc_];
        scoreobj[2].sprite = levelrender[tram_];
        scoreobj[3].sprite = levelrender[nghin_];
        scoreobj[4].sprite = levelrender[chucnghin_];
        if (score >= 10000)
            scoreobj[4].enabled = true;
        else
        {
            scoreobj[4].enabled = false;
        }

        if (score >= 1000)
            scoreobj[3].enabled = true;
        else
        {
            scoreobj[3].enabled = false;
        }
        if (score >= 100)
            scoreobj[2].enabled = true;
        else
            scoreobj[2].enabled = false;
        if (score >= 10)
            scoreobj[1].enabled = true;
        else
            scoreobj[1].enabled = false;
        float posx = 1.81f;

        if (score >= 10000)
            posx = 1.89f;
        else
            if (score < 1000)
                if (score >= 100)
                    posx = 1.73f;
                else
                    if (score >= 10)
                        posx = 1.65f;
                    else
                        posx = 1.57f;

        Vector3 vttemp = new Vector3(posx, scoreobj[0].gameObject.transform.localPosition.y, scoreobj[0].gameObject.transform.localPosition.z);
        scoreobj[0].gameObject.transform.localPosition = vttemp;

    }

    void targetscorehow()
    {
        int chucnghin = 0;
        int nghin = 0;
        int tram = 0;
        int chuc = 0;
        int dv = 0;
        int temp = 0;
        chucnghin = GlobalValues.TargetScore / 10000;
        temp = GlobalValues.TargetScore % 10000;
        nghin = temp / 1000;
        temp = temp % 1000;
        tram = temp / 100;
        temp = temp % 100;
        chuc = temp / 10;
        temp = temp % 10;
        dv = temp;
        float posx = 0.15f;
        if (GlobalValues.TargetScore >= 10000)
        {
            targerScore[4].gameObject.SetActive(true);
            posx = 0.3f;
        }
        else
            targerScore[4].gameObject.SetActive(false);
        targerScore[0].sprite = levelrender[dv];
        targerScore[1].sprite = levelrender[chuc];
        targerScore[2].sprite = levelrender[tram];
        targerScore[3].sprite = levelrender[nghin];
        targerScore[4].sprite = levelrender[chucnghin];

        Vector3 vttemp = new Vector3(posx, targerScore[0].gameObject.transform.position.y, targerScore[0].gameObject.transform.position.z);
        targerScore[0].gameObject.transform.position = vttemp;
    }

    Sprite renderNumber(int number, Sprite[] sprite)
    {
        return sprite[number];
    }

}
