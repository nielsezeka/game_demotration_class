using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class WelcomeUI : MonoBehaviour
{

    bool isHold = false;
    bool select = false;
    string nameObj = "";

    //button
    public GameObject[] soundButton = new GameObject[4];
    public GameObject[] PlayButton = new GameObject[2];

    public GameObject soundb;

    void Start()
    {
        //load last sound/music button state
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            soundButton[0].SetActive(true);
            TraverseScreenScript.isMusic = true;
            GameObject.Find("SoundEff").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            soundButton[2].SetActive(true);
            TraverseScreenScript.isMusic = false;
            GameObject.Find("SoundEff").GetComponent<AudioSource>().mute = true;
        }
        DontDestroyOnLoad(soundb);

        GlobalValues.TargetScore = 0;
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
            if (checkTouch(Input.mousePosition) != null)
            {
                if (checkTouch(Input.mousePosition).name == nameObj)
                    addAction(nameObj);
            }
        }
        if (isHold)
        {
            if (!select)
            {
                if (checkTouch(Input.mousePosition) != null)
                {
                    holdeffect(checkTouch(Input.mousePosition).name);
                    nameObj = checkTouch(Input.mousePosition).name;
                }
            }
            select = true;
        }
        else
        {
            unSelect();
        }

        // Exit Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    /// <summary>
    /// set button action by name
    /// </summary>
    /// <param name="nameobj">button name</param>
    void addAction(string nameobj)
    {
        switch (nameobj)
        {
            case "play":
                Application.LoadLevel("select_map");
                if (TraverseScreenScript.isMusic)
                {
                    soundb.GetComponent<AudioSource>().Play();
                    Destroy(soundb, 0.3f);
                }
                break;
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
            default:
                break;
        }
    }
    /// <summary>
    /// set button state by name
    /// </summary>
    /// <param name="nameobj">button name</param>
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
            case "play":
                PlayButton[1].SetActive(true);
                break;

            default:
                break;
        }
    }
    /// <summary>
    /// when button not select
    /// </summary>
    void unSelect()
    {
        soundButton[1].SetActive(false);
        soundButton[3].SetActive(false);
        PlayButton[1].SetActive(false);
    }
    /// <summary>
    ///  touch detectetion
    /// </summary>
    /// <param name="pos">mouseposition</param>
    /// <returns></returns>
    GameObject checkTouch(Vector3 pos)
    {

        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        GameObject ObjPointer = null;
        if (Physics2D.OverlapPoint(touchPos))
            ObjPointer = Physics2D.OverlapPoint(touchPos).gameObject;

        return ObjPointer;
    }
}
