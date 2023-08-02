using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseScrips : MonoBehaviour
{

    // Use this for initialization
    bool isHold = false;
    bool select = false;
    string nameObj = "";
    public GameObject moreapp;
    public GameObject main;

    public GameObject pausebr;
    public GameObject[] soundButton = new GameObject[4];
    public GameObject[] menuButton = new GameObject[2];
    public GameObject[] resumeButton = new GameObject[2];
    public GameObject[] MoreButton = new GameObject[2];
    public GameObject[] soundeff = new GameObject[5];
    public SpriteRenderer[] textPauseRender;
    public Sprite[] textPauseSprite;
    public GameObject IconAd;
    public Transform parent;

    int[] lstIndex = new int[3];

    void Start()
    {
        if (TraverseScreenScript.isMusic)
            soundButton[0].SetActive(true);
        else
            soundButton[2].SetActive(true);
    }


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
            case "sound":
                soundButton[2].SetActive(true);
                soundButton[0].SetActive(false);
                GameObject.Find("SoundEff").GetComponent<AudioSource>().mute = true;
                TraverseScreenScript.isMusic = false;
                PlayerPrefs.SetInt("Sound", 0);
                break;
            case "soundoff":
                soundButton[0].SetActive(true);
                soundButton[2].SetActive(false);
                GameObject.Find("SoundEff").GetComponent<AudioSource>().mute = false;
                TraverseScreenScript.isMusic = true;
                PlayerPrefs.SetInt("Sound", 1);
                break;
            case "menu":
                Application.LoadLevel("welcome");

                break;
            case "resume":
                pausebr.SetActive(false);
                GlobalValues.isPause = false;
                break;
            case "restart":
                Application.LoadLevel("play");
                break;
            default:
                break;
        }
    }

    void holdeffect(string nameobj)
    {
        switch (nameobj)
        {
            case "sound":
                soundButton[1].SetActive(true);
                break;
            case "soundoff":
                soundButton[3].SetActive(true);
                break;
            case "menu":
                menuButton[1].SetActive(true);
                textPauseRender[4].enabled = false;
                break;
            case "resume":
                resumeButton[1].SetActive(true);
                textPauseRender[0].enabled = false;
                break;
            case "Moregame":
                MoreButton[1].SetActive(true);
                textPauseRender[2].enabled = false;
                break;
            case "restart":
                resumeButton[1].SetActive(true);
                break;
            default:
                break;
        }
    }

    void unSelect()
    {
        soundButton[1].SetActive(false);
        soundButton[3].SetActive(false);
        menuButton[1].SetActive(false);
        resumeButton[1].SetActive(false);
        MoreButton[1].SetActive(false);
        textPauseRender[0].enabled = true;
        textPauseRender[2].enabled = true;
        textPauseRender[4].enabled = true;

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
    bool CheckExist(int l)
    {
        foreach (int h in lstIndex)
            if (l == h)
                return true;
        return false;

    }
}
