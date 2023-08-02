using UnityEngine;
using System.Collections;
using System.IO;
public class WinUI : MonoBehaviour
{

    bool isHold = false;
    bool select = false;
    string nameObj = "";
    public GameObject[] RetryButton = new GameObject[2];
    public GameObject[] MenuButton = new GameObject[2];
    public GameObject[] NextButton = new GameObject[2];
    public Sprite[] number = new Sprite[10];
    public SpriteRenderer[] ScoreNumbers = new SpriteRenderer[5];
    public SpriteRenderer[] BestScoreNumbers = new SpriteRenderer[5];
    public Sprite[] starsprite = new Sprite[2];
    public SpriteRenderer[] StarsPos = new SpriteRenderer[3];
    public GameObject sound;


    void Start()
    {
        GlobalValues.isWinUI = true;

        showScore(GlobalValues.Score, ScoreNumbers, number);
        if (GlobalValues.BestScore < GlobalValues.Score)
            GlobalValues.BestScore = GlobalValues.Score;
        showScore(GlobalValues.TargetScore, BestScoreNumbers, number);
        showStars(GlobalValues.Stars);

        if (TraverseScreenScript.isMusic)
            Destroy(Instantiate(sound), 2.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHold = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHold = false;
            select = false;
            if (checkTouch(Input.mousePosition).name == nameObj)
                addAction(nameObj);
        }
        if (isHold)
        {
            if (!select)
            {
                holdeffect(checkTouch(Input.mousePosition).name);
                nameObj = checkTouch(Input.mousePosition).name;
            }
            select = true;
        }
        else
        {
            unSelect();
        }

    }

    void addAction(string nameobj)
    {
        switch (nameobj)
        {
            case "retry":
                Application.LoadLevel("play");
                break;
            case "next":
                Save(GlobalValues.level);
                GlobalValues.level++;
                if (GlobalValues.level > 84)
                    GlobalValues.level = 1;
                Application.LoadLevel("play");
                break;
            case "menu":
                Application.LoadLevel("welcome");
                break;
            default:
                break;
        }
    }

    void holdeffect(string nameobj)
    {
        switch (nameobj)
        {
            case "retry":
                RetryButton[1].SetActive(true);
                break;
            case "menu":
                MenuButton[1].SetActive(true);
                break;
            case "next":
                NextButton[1].SetActive(true);
                break;

            default:
                break;
        }
    }

    void unSelect()
    {
        RetryButton[1].SetActive(false);
        MenuButton[1].SetActive(false);
        NextButton[1].SetActive(false);

    }

    GameObject checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        GameObject ObjPointer = null;
        if (Physics2D.OverlapPoint(touchPos))
            ObjPointer = Physics2D.OverlapPoint(touchPos).gameObject;

        return ObjPointer;

    }

    void showScore(int score, SpriteRenderer[] renderer, Sprite[] number)
    {
        int chucnghin = 0;
        int nghin_ = 0;
        int tram_ = 0;
        int chuc_ = 0;
        int dv_ = 0;
        int temp_ = 0;
        chucnghin = score / 10000;
        temp_ = score % 10000;
        nghin_ = temp_ / 1000;
        temp_ = temp_ % 1000;
        tram_ = temp_ / 100;
        temp_ = temp_ % 100;
        chuc_ = temp_ / 10;
        temp_ = temp_ % 10;
        dv_ = temp_;
        renderer[0].sprite = number[dv_];
        renderer[1].sprite = number[chuc_];
        renderer[2].sprite = number[tram_];
        renderer[3].sprite = number[nghin_];
        renderer[4].sprite = number[chucnghin];

        if (score >= 10000)
            renderer[4].enabled = true;
        else
        {
            renderer[4].enabled = false;
        }

        if (score >= 1000)
            renderer[3].enabled = true;
        else
        {
            renderer[3].enabled = false;
        }
        if (score >= 100)
            renderer[2].enabled = true;
        else
            renderer[2].enabled = false;
        if (score >= 10)
            renderer[1].enabled = true;
        else
            renderer[1].enabled = false;
    }

    void showStars(int star)
    {
        for (int i = 0; i < star; i++)
            StarsPos[i].sprite = starsprite[1];

    }
    Sprite renderNumber(int number, Sprite[] sprite)
    {
        return sprite[number];
    }

    void Save(int lv)
    {
        foreach (Map m in GlobalValues.Maps)
        {
            if (m.Level == lv)
            {
                m.HightScore = GlobalValues.BestScore;
                if (GlobalValues.Stars > m.Stars)
                    m.Stars = GlobalValues.Stars;
            }
            else if (m.Level == lv + 1)
            {
                m.Locked = false;
                break;
            }
        }

        string path = Application.persistentDataPath + @"/DataFile/MapData.dat";
        FileUtils f = new FileUtils();
        f.path = path;
        f.Maps = GlobalValues.Maps;
        f.Save();
        Debug.Log("saved!");
    }
}
