using UnityEngine;
using System.Collections;

public class selectMapMove : MonoBehaviour
{

    public GameObject[] BackButton = new GameObject[2];
    public GameObject suo;
    bool isHold = false;
    bool select = false;
    string nameobj = "";
    int group = 0;
    float rootPosX;
    public float count = 0;

    public SpriteRenderer[] stick;
    public Sprite[] stickrsprite;
    public GameObject[] Group = new GameObject[6];

    void Start()
    {
        EnableGroup(group);
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
            if (checkTouch(Input.mousePosition) != null)
            {
                if (checkTouch(Input.mousePosition).name == nameobj)
                    addaction(checkTouch(Input.mousePosition));
            }
        }
        if (isHold && !select)
        {

            if (checkTouch(Input.mousePosition) != null)
            {
                nameobj = checkTouch(Input.mousePosition).name;
            }

            select = true;
        }

        if (isHold)
        {
            if (checkTouch(Input.mousePosition) != null)
            {
                holdeffect(checkTouch(Input.mousePosition).name);
            }
        }
        else
            unSelect();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("welcome");


    }
    void setStick(int g)
    {
        foreach (SpriteRenderer r in stick)
            r.sprite = stickrsprite[0];
        stick[g].sprite = stickrsprite[1];
    }

    void addaction(GameObject obj)
    {
        if (obj.name.Contains("xing") && !obj.GetComponent<MapInf>().Locked)
        {
            Application.LoadLevel("play");
            GlobalValues.level = obj.GetComponent<MapInf>().Level;

            GlobalValues.Maps = Data.maps;
        }
        if (obj.name == "ButtonNext")
        {
            group++;
            if (group > 5)
                group = 0;
            setStick(group);
            EnableGroup(group);
        }
        if (obj.name == "ButtonReview")
        {
            group--;
            if (group < 0)
                group = 5;
            setStick(group);
            EnableGroup(group);
        }
        if (obj.name == "back")
        {
            Application.LoadLevel("welcome");
        }


    }

    void holdeffect(string nameobj)
    {
        switch (nameobj)
        {
            case "back":
                BackButton[1].SetActive(true);
                break;
        }
    }
    void unSelect()
    {
        BackButton[1].SetActive(false);

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
    void EnableGroup(int g)
    {
        for (int i = 0; i < 6; i++)
            Group[i].SetActive(false);
        Group[g].SetActive(true);
    }

}
