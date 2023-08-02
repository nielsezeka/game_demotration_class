using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fruitSpawn : MonoBehaviour
{

    // Use this for initialization
    public GameObject fruits;
    public Sprite[] fruitsSpriteShawdow;
    public Sprite[] fruitsSpriteStrocke;
    public GameObject screenscale;
    public static float[] posx = { -2.55f, -1.7f, -0.85f, 0, 0.85f, 1.7f, 2.55f };
    public static float[] localposx = { -2.0f, -1.33f, -0.68f, 0, 0.68f, 1.36f, 2.02f };
    public static List<Vector2> DestroyListPos = new List<Vector2>();
    public int count = 0;
    int[] posy = new int[7];
    bool isSpawn = true;

    int temp;
    int posx_;
    int id = 0;
    void Start()
    {
        GlobalValues.FruitMap.Clear();

        //spawn fruits
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 7; j++)
            {
                temp = Random.Range(0, 5);
                fruits.GetComponent<SpriteRenderer>().sprite = fruitsSpriteShawdow[GlobalValues.FruitCollect[temp] - 1];
                fruits.transform.Find("bingdongselected").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fruitsSpriteStrocke[GlobalValues.FruitCollect[temp] - 1];
                fruits.transform.Find("select").GetComponent<SpriteRenderer>().sprite = fruitsSpriteStrocke[GlobalValues.FruitCollect[temp] - 1];
                fruits.GetComponent<Fruit>().fruitID = j;
                fruits.GetComponent<Fruit>().type = GlobalValues.FruitCollect[temp];
                fruits.GetComponent<Fruit>().positionMap = new Vector2(i, j);
                fruits.GetComponent<Fruit>().FruitPower = 0;
                Vector3 vt3 = new Vector3(localposx[i], 6.5f + j * 0.9f, -1);
                GameObject ObjTemp = Instantiate(fruits) as GameObject;
                ObjTemp.transform.parent = screenscale.transform;
                ObjTemp.transform.localPosition = vt3;
                GlobalValues.FruitMap.Add(ObjTemp);
                id++;
            }
        //add start power
        addEffect(GlobalValues.FreezeFruit, -1);
        addEffect(GlobalValues.TypePower1, 1);
        addEffect(GlobalValues.TypePower2, 2);
        addEffect(GlobalValues.TypePower3, 3);
    }
    /// <summary>
    /// check lost fruit then add
    /// </summary>
    void Update()
    {
        count = DestroyListPos.Count;
        if (count > 0)
            isSpawn = false;
        else
        {
            posy[0] = 0; posy[1] = 0; posy[2] = 0; posy[3] = 0; posy[4] = 0; posy[5] = 0; posy[6] = 0;
        }

        checkSpawn();
    }

    void addEffect(int c, int power)
    {
        int count = 0;
        while (count < c)
        {
            GameObject ObjTemp = GlobalValues.FruitMap[Random.Range(0, 49)];
            if (ObjTemp.GetComponent<Fruit>().FruitPower == 0)
            {
                ObjTemp.GetComponent<Fruit>().FruitPower = power;
                count++;
            }
        }

    }

    void checkSpawn()
    {
        if (!isSpawn)
        {
            FruitSpawn(fruits, DestroyListPos[0]);
            int idx = (int)DestroyListPos[0].x;
            posy[idx]++;
            DestroyListPos.RemoveAt(0);
            isSpawn = true;
        }
    }
    /// <summary>
    /// Instantiate fruit,set properites and set position matrix
    /// </summary>
    /// <param name="objSpawn"></param>
    /// <param name="posMap"></param>
    void FruitSpawn(GameObject objSpawn, Vector2 posMap)
    {
        int index = Random.Range(0, 5);
        objSpawn.GetComponent<SpriteRenderer>().sprite = fruitsSpriteShawdow[GlobalValues.FruitCollect[index] - 1];
        objSpawn.transform.Find("bingdongselected").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fruitsSpriteStrocke[GlobalValues.FruitCollect[index] - 1];
        objSpawn.transform.Find("select").GetComponent<SpriteRenderer>().sprite = fruitsSpriteStrocke[GlobalValues.FruitCollect[index] - 1];
        objSpawn.GetComponent<Fruit>().type = GlobalValues.FruitCollect[index];
        int dem = 0;
        foreach (GameObject obj_ in GlobalValues.FruitMap)
            if (obj_.GetComponent<Fruit>().positionMap.x == posMap.x)
                dem++;

        objSpawn.GetComponent<Fruit>().positionMap = new Vector2(posMap.x, dem);

        Vector3 vtTemp = new Vector3(localposx[(int)posMap.x], 6.5f + 1.3f * posy[(int)posMap.x], objSpawn.transform.position.z);

        GameObject tempObj = Instantiate(objSpawn) as GameObject;

        tempObj.transform.parent = screenscale.transform;
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.transform.localPosition = vtTemp;
        tempObj.GetComponent<Fruit>().FruitPower = 0;

        GlobalValues.FruitMap.Add(tempObj);
    }

    /// <summary>
    /// find min position on list
    /// </summary>
    /// <param name="listdes"></param>
    /// <returns></returns>
    int MinPos(List<Vector2> listdes)
    {
        Vector2 temp = listdes[0];
        foreach (Vector2 obj in listdes)
            if (temp.y > obj.y)
                temp = obj;
        return listdes.IndexOf(temp);
    }

}