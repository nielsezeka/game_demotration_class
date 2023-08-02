using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour
{

    // Use this for initialization

    public static void ScoreEffectSpawn(int Scrore, GameObject obj, GameObject[] ObjAnimation, GameObject StarEffect)
    {
        int temp = 0;
        switch (Scrore)
        {
            case -5:
                temp = 0;
                break;
            case 10:
                temp = 1;
                break;
            case 20:
                temp = 2;
                break;
            default:
                break;
        }

        obj.GetComponent<Renderer>().enabled = false;
        Destroy(obj.transform.GetChild(2).gameObject);

        GameObject ObjTemp = Instantiate(ObjAnimation[temp]) as GameObject;
        ObjTemp.transform.parent = obj.transform;

        GameObject ObjTemp1 = Instantiate(StarEffect, obj.transform.position, obj.transform.rotation) as GameObject;
        ObjTemp1.transform.parent = obj.transform;


    }

    public static void ScoreBonusSpawn(GameObject[] ObjAnimation, int temp, GameObject[] soundeff)
    {

        if (temp >= 2 && TraverseScreenScript.isMusic)
            Destroy(Instantiate(soundeff[1]) as GameObject, 1.2f);

        if (temp >= 6 && temp < 10)
        {
            GameObject ObjTemp = Instantiate(ObjAnimation[0]) as GameObject;
            Destroy(ObjTemp, 0.7f);
            GlobalValues.Score += 100;
            bool inc = false;
            while (!inc)
            {
                int PowerInc = Random.Range(0, GlobalValues.FruitMap.Count);
                GameObject obj = GlobalValues.FruitMap[PowerInc];
                if (obj.GetComponent<Fruit>().isSelected == false && obj.GetComponent<Fruit>().isDestroy == false && obj.GetComponent<Fruit>().FruitPower == 0)
                {
                    obj.GetComponent<Fruit>().FruitPower = 1;
                    inc = true;
                }
            }

        }
        else if (temp >= 10 && temp < 15)
        {
            GameObject ObjTemp = Instantiate(ObjAnimation[1]) as GameObject;
            Destroy(ObjTemp, 0.7f);
            GlobalValues.Score += 200;
            GlobalValues.isBonus = true;
            bool inc = false;
            while (!inc)
            {
                int PowerInc = Random.Range(0, GlobalValues.FruitMap.Count);
                GameObject obj = GlobalValues.FruitMap[PowerInc];
                if (obj.GetComponent<Fruit>().isSelected == false && obj.GetComponent<Fruit>().isDestroy == false && obj.GetComponent<Fruit>().FruitPower == 0)
                {
                    obj.GetComponent<Fruit>().FruitPower = 2;
                    inc = true;
                }
            }
        }
        else if (temp >= 15)
        {
            GameObject ObjTemp = Instantiate(ObjAnimation[1]) as GameObject;
            Destroy(ObjTemp, 0.7f);
            GlobalValues.Score += 200;
            GlobalValues.isBonus = true;
            bool inc = false;
            while (!inc)
            {
                int PowerInc = Random.Range(0, GlobalValues.FruitMap.Count);
                GameObject obj = GlobalValues.FruitMap[PowerInc];
                if (obj.GetComponent<Fruit>().isSelected == false && obj.GetComponent<Fruit>().isDestroy == false && obj.GetComponent<Fruit>().FruitPower == 0)
                {
                    obj.GetComponent<Fruit>().FruitPower = 3;
                    inc = true;
                }

            }
        }

    }
}