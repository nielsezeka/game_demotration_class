using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalValues : MonoBehaviour
{
    public static int FreezeFruit = 0;
    public static int TypePower1 = 0;
    public static int TypePower2 = 0;
    public static int TypePower3 = 0;
    public static int[] FruitCollect = { 1, 2, 3, 4, 8 };
    public static float LimitTime = 0;
    public static int level = 1;
    public static int TargetScore = 0;
    public static int Score = 0;
    public static int BestScore = 0;
    public static int Stars = 0;
    public static List<Map> Maps;
    public static bool isMusic;
    public static List<GameObject> FruitMap = new List<GameObject>();
    public static List<GameObject> FruitSelect = new List<GameObject>();
    public static List<GameObject> Lines = new List<GameObject>();
    public static bool isBonus;
    public static bool isPause = false;
    public static bool isGameoverUI = false;
    public static bool isWinUI = false;
    public static float Countdown = 0;
    public static bool isgameover = false;
    public static bool cdstart = false;
    public static float admobshowtime = 120f;

    void Awake()
    {
        setMapinf(level);
    }
    void Start()
    {
        Countdown = LimitTime;
        Score = 0;
        FruitSelect.Clear();
        Lines.Clear();
        isPause = false;
        isGameoverUI = false;
        isWinUI = false;
        cdstart = false;
    }
    public static void addFruit(GameObject objfruit)
    {
        if (CheckFruitSelect(objfruit))
            FruitSelect.Add(objfruit);
    }

    public static bool CheckFruitSelect(GameObject objfruit)
    {
        foreach (GameObject i in FruitSelect)
            if (i.GetComponent<Fruit>().positionMap == objfruit.GetComponent<Fruit>().positionMap)
                return false;
        return true;
    }

    public static void DestroyFruit(GameObject soundboli)
    {
        int PowerCount = 0;
        foreach (GameObject k in FruitSelect)
            if (k != null && k.GetComponent<Fruit>().FruitPower == 0)
                PowerCount++;

        if (FruitSelect.Count >= 2 && PowerCount > 1 || FruitSelect.Count >= 3)
        {
            foreach (GameObject i in FruitSelect)
            {
                if (i != null)
                {
                    int power = i.GetComponent<Fruit>().FruitPower;
                    if (power != -1)
                    {
                        SetScore(FruitSelect, i);
                        i.GetComponent<Fruit>().isDestroy = true;
                    }
                    else if (power == -1)
                    {
                        i.GetComponent<Fruit>().UnFreeze = true;
                        i.GetComponent<Fruit>().FruitPower = 0;
                        i.GetComponent<Fruit>().isSelected = false;
                        if (TraverseScreenScript.isMusic)
                            Destroy(Instantiate(soundboli), 1.2f);
                    }
                }
            }
        }
        if (FruitSelect.Count == 2 && FruitSelect[0] != null)
        {
            FruitSelect[0].GetComponent<Fruit>().isSelected = false;
            FruitSelect[1].GetComponent<Fruit>().isSelected = false;
        }
        else if (FruitSelect.Count == 1 && FruitSelect[0] != null)
            FruitSelect[0].GetComponent<Fruit>().isSelected = false;
        FruitSelect.Clear();
    }

    public static void DestroyLines()
    {
        foreach (GameObject i in Lines)
            Destroy(i);
    }

    public static void SetScore(List<GameObject> listselect, GameObject obj)
    {
        int temp = listselect.Count;
        int tempScore = 0;
        if (temp == 2)
            tempScore = -5;
        else if (temp >= 3 && temp <= 5)
            tempScore = 10;
        else if (temp >= 6)
            tempScore = 20;
        obj.GetComponent<Fruit>().Score = tempScore;
    }

    void setMapinf(int lv)
    {

        foreach (Map m in Maps)
            if (m.Level == lv)
            {
                TargetScore = m.TargetScore;
                LimitTime = m.LimitTime;
                FruitCollect = m.Fruits;
                FreezeFruit = m.Freeze;
                TypePower1 = m.Power1;
                TypePower2 = m.Power2;
                TypePower3 = m.Power3;
                BestScore = m.HightScore;
                break;
            }
    }

}
