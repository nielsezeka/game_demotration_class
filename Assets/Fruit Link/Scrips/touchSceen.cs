using UnityEngine;
using System.Collections;

public class touchSceen : MonoBehaviour
{

    // Use this for initialization
    public bool isHold;
    public GameObject lines;
    public GameObject[] bonusScoreEffect = new GameObject[2];
    public GameObject PauseUI;
    public GameObject[] soundeff;
    bool ms = false;
    bool start;
    GameObject ObjStart;
    int typeF;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GlobalValues.cdstart)
        {
            ms = false;
            ObjStart = null;
            typeF = -1;
            isHold = true;
            start = false;
            GlobalValues.isBonus = false;
            checkPause(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0) && GlobalValues.cdstart)
        {

            isHold = false;
        }
        if (isHold)
            checkTouch(Input.mousePosition);
        else
        {
            GlobalValues.DestroyLines();			
            Scores.ScoreBonusSpawn(bonusScoreEffect, GlobalValues.FruitSelect.Count, soundeff);
            GlobalValues.DestroyFruit(soundeff[2]);
            GlobalValues.FruitSelect.Clear();
        }
        //back press action
        if (Input.GetKeyDown(KeyCode.Escape) && !GlobalValues.isPause && !GlobalValues.isGameoverUI && !GlobalValues.isWinUI)
        {
            PauseUI.SetActive(true);
            GlobalValues.isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GlobalValues.isPause && !GlobalValues.isGameoverUI && !GlobalValues.isWinUI)
        {
            PauseUI.SetActive(false);
            GlobalValues.isPause = false;
        }
    }
    /// <summary>
    /// check player touch by condition:
    /// - fruit type
    /// - distance
    /// true :
    /// - add line
    /// - add to select list
    /// false
    /// - destroy line
    /// - remmove from select list
    /// </summary>
    /// <param name="pos"></param>
    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        if (Physics2D.OverlapPoint(touchPos))
        {
            GameObject ObjPointer = Physics2D.OverlapPoint(touchPos).gameObject;
            if (ObjPointer.name.Contains("fruit"))
            {
                if (!start)
                {
                    typeF = ObjPointer.GetComponent<Fruit>().type;
                    GlobalValues.FruitSelect.Add(ObjPointer);
                    GlobalValues.FruitSelect[0].GetComponent<Fruit>().isSelected = true;
                    ObjStart = ObjPointer;
                    start = true;

                }
                if (!ms && TraverseScreenScript.isMusic)
                {
                    GetComponent<AudioSource>().Play();
                    ms = true;
                }
                if (ObjPointer != ObjStart)
                {								
                    int PointerType = ObjPointer.GetComponent<Fruit>().type;
                    if (PointerType == typeF && distanceCheck(ObjStart, ObjPointer))
                    {
                        ms = false;
                        if (GlobalValues.CheckFruitSelect(ObjPointer))
                        {
                            if (ObjStart != GlobalValues.FruitSelect[GlobalValues.FruitSelect.Count - 1])
                                ObjStart = GlobalValues.FruitSelect[GlobalValues.FruitSelect.Count - 1];
                            if (ObjPointer == GlobalValues.FruitSelect[0])
                            {
                                isHold = false;

                            }
                            if (!distanceCheck(ObjStart, ObjPointer))
                                isHold = false;
                            else
                            {
                                LineSpawn(ObjStart, ObjPointer);
                                ObjPointer.GetComponent<Fruit>().isSelected = true;
                                GlobalValues.FruitSelect.Add(ObjPointer);
                            }
                        }
                        else if (GlobalValues.FruitSelect.Count > 1 && ObjPointer == GlobalValues.FruitSelect[GlobalValues.FruitSelect.Count - 2])
                        {
                            Destroy(GlobalValues.Lines[GlobalValues.Lines.Count - 1]);
                            GlobalValues.Lines.RemoveAt(GlobalValues.Lines.Count - 1);

                            GlobalValues.FruitSelect[GlobalValues.FruitSelect.Count - 1].GetComponent<Fruit>().isSelected = false;
                            GlobalValues.FruitSelect.RemoveAt(GlobalValues.FruitSelect.Count - 1);
                        }
                        ObjStart = ObjPointer;
                    }
                    else
                    {
                        if (!distanceCheck(ObjStart, ObjPointer))
                            isHold = false;
                    }

                }
            }
        }
    }
    /// <summary>
    /// when click pause button
    /// </summary>
    /// <param name="pos"></param>
    void checkPause(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        if (Physics2D.OverlapPoint(touchPos))
        {
            GameObject ObjPointer = Physics2D.OverlapPoint(touchPos).gameObject;
            if (ObjPointer.name == "pause")
            {
                PauseUI.SetActive(true);
                GlobalValues.isPause = true;
            }
        }
    }
    /// <summary>
    /// add line between 2 fruits
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    void LineSpawn(GameObject obj1, GameObject obj2)
    {
        Vector3 linePos = new Vector3((obj1.transform.position.x + obj2.transform.position.x) / 2,
                               (obj1.transform.position.y + obj2.transform.position.y) / 2,
                               0.005f);
        Quaternion rotation = Quaternion.Euler(0, 0, rotationz(obj1, obj2));
        GlobalValues.Lines.Add(Instantiate(lines, linePos, rotation) as GameObject);
    }
    /// <summary>
    /// destroy line
    /// </summary>
    void desLines()
    {

        Destroy(GameObject.Find("line"));
    }
    /// <summary>
    /// calculating line angles
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="selected"></param>
    /// <returns></returns>
    float rotationz(GameObject obj, GameObject selected)
    {
        Vector2 objPosMap = obj.GetComponent<Fruit>().positionMap;
        Vector2 selectedPosMap = selected.GetComponent<Fruit>().positionMap;
        if (objPosMap.x == selectedPosMap.x)
            return 0;
        if (objPosMap.y == selectedPosMap.y)
            return 90f;
        float temp = (objPosMap.x - selectedPosMap.x) * (objPosMap.y - selectedPosMap.y);

        if (temp < 0)
            return 45f;
        else
            return -45f;

    }
    /// <summary>
    /// check distance 2 fruits.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="selected"></param>
    /// <returns></returns>
    bool distanceCheck(GameObject obj, GameObject selected)
    {
        if (obj != null)
        {
            Vector2 temp = obj.GetComponent<Fruit>().positionMap;
            Vector2 temp1 = selected.GetComponent<Fruit>().positionMap;
            Vector2 comp = new Vector2(Mathf.Abs(temp.x - temp1.x), Mathf.Abs(temp.y - temp1.y));
            if (comp.x > 1 || comp.y > 1)
            {

                return false;
            }
            return true;
        }
        return false;
    }

    bool checkIDfruit(Vector2[] ObjArray, Vector2 pos)
    {
        foreach (Vector2 i in ObjArray)
        {
            if (i == pos)
                return false;
        }
        return true;
    }

}
