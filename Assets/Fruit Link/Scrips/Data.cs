using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Data : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] parent;
    public GameObject rootpos;
    float[] pox_x = { -2.56f, -1.68f, -0.8f, 0.08f };
    public GameObject ObjMap;
    public Sprite[] MapStar;
    public Sprite[] Number;
    List<Vector3> pos = new List<Vector3>();
    public static List<Map> maps;
    float hight = -1.04f;

  
    void Start()
    {
        //get path
        string path = Application.persistentDataPath + @"/DataFile/MapData.dat";
        if (!File.Exists(path))
        {
            defaultMap(); // create new
        }

        maps = new List<Map>();
        FileUtils f = new FileUtils();
        f.path = path;
        maps = f.load();

        for (int k = 0; k < 6; k++)
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Vector3 vt3 = new Vector3(pox_x[j], i * hight, 0);
                    pos.Add(vt3);
                }
        
        foreach (Map m in maps)
            showMap(m);

    }
    void showMap(Map map_)
    {

        if (map_.Level <= 16)
            Show(map_, parent[0]);
        else if (map_.Level <= 32)
            Show(map_, parent[1]);
        else if (map_.Level <= 48)
            Show(map_, parent[2]);
        else if (map_.Level <= 64)
            Show(map_, parent[3]);
        else if (map_.Level <= 80)
            Show(map_, parent[4]);
        else if (map_.Level <= 96)
            Show(map_, parent[5]);

    }
    /// <summary>
    /// create and set button properties and add to group
    /// </summary>
    /// <param name="mapt_"></param>
    /// <param name="parent"></param>
    void Show(Map mapt_, GameObject parent)
    {
        GameObject ObjTemp = ObjMap;
        GameObject obj = (Instantiate(ObjTemp) as GameObject);
        setStar(mapt_, obj);
        setNumber(mapt_, obj);
        obj.transform.parent = parent.transform;
        obj.transform.localPosition = pos[mapt_.Level - 1];
        obj.name += mapt_.Level;
        obj.GetComponent<MapInf>().Level = mapt_.Level;
        obj.GetComponent<MapInf>().Locked = mapt_.Locked;

    }
    /// <summary>
    /// Set star in button map
    /// </summary>
    /// <param name="m"></param>
    /// <param name="O"></param>
    void setStar(Map m, GameObject O)
    {
        if (m.Locked)
            O.GetComponent<SpriteRenderer>().sprite = MapStar[0];
        else
        {
            switch (m.Stars)
            {
                case 0:
                    O.GetComponent<SpriteRenderer>().sprite = MapStar[1];
                    break;
                case 1:
                    O.GetComponent<SpriteRenderer>().sprite = MapStar[2];
                    break;
                case 2:
                    O.GetComponent<SpriteRenderer>().sprite = MapStar[3];
                    break;
                case 3:
                    O.GetComponent<SpriteRenderer>().sprite = MapStar[4];
                    break;
            }
        }
    }
    /// <summary>
    /// Set number in button map
    /// </summary>
    /// <param name="m"></param>
    /// <param name="o"></param>
    void setNumber(Map m, GameObject o)
    {
        if (!m.Locked)
        {
            GameObject temp = o.transform.GetChild(0).gameObject;
            if (m.Level < 10)
            {
                temp.transform.GetChild(0).gameObject.SetActive(false);
                temp.GetComponent<SpriteRenderer>().sprite = Number[m.Level];
            }
            else if (m.Level < 100)
            {
                temp.transform.localPosition = new Vector3(0.08f, temp.transform.localPosition.y, temp.transform.localPosition.z);
                int chuc = 0;
                int dv = 0;
                chuc = m.Level / 10;
                dv = m.Level % 10;
                temp.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Number[chuc];
                temp.GetComponent<SpriteRenderer>().sprite = Number[dv];
            }
            o = temp;
        }
        else
            o.transform.GetChild(0).gameObject.SetActive(false);

    }
    /// <summary>
    /// default data for the first time
    /// - id fruits
    /// - target score/lv
    /// - fruits power
    /// </summary>
    void defaultMap()
    {

        List<int[]> p = new List<int[]>();
        int[] temp1 = { 1, 2, 3, 4, 5 }; p.Add(temp1);
        int[] temp2 = { 2, 3, 4, 5, 6 }; p.Add(temp2);
        int[] temp3 = { 3, 4, 5, 6, 7 }; p.Add(temp3);
        int[] temp4 = { 3, 4, 5, 6, 7 }; p.Add(temp4);
        int[] temp5 = { 1, 4, 5, 6, 7 }; p.Add(temp5);
        int[] temp6 = { 1, 2, 3, 6, 7 }; p.Add(temp6);
        int[] temp7 = { 1, 2, 3, 4, 7 }; p.Add(temp7);
        int[] temp8 = { 1, 2, 3, 4, 5 }; p.Add(temp8);
        int[] temp9 = { 2, 3, 4, 5, 6 }; p.Add(temp9);
        int[] temp10 = { 2, 3, 4, 5, 6 }; p.Add(temp10);
        int[] temp11 = { 3, 4, 5, 6, 7 }; p.Add(temp11);
        int[] temp12 = { 2, 4, 5, 6, 7 }; p.Add(temp12);
        int[] temp13 = { 2, 4, 5, 6, 7 }; p.Add(temp13);
        int[] temp14 = { 1, 2, 4, 5, 6 }; p.Add(temp14);
        int[] temp15 = { 1, 2, 3, 4, 7 }; p.Add(temp15);
        int[] temp16 = { 1, 2, 3, 4, 5 }; p.Add(temp16);
        int[] temp17 = { 1, 2, 3, 4, 5 }; p.Add(temp17);
        int[] temp18 = { 2, 3, 4, 5, 6 }; p.Add(temp18);
        int[] temp19 = { 3, 4, 5, 6, 7 }; p.Add(temp19);
        int[] temp20 = { 3, 4, 5, 6, 7 }; p.Add(temp20);
        int[] temp21 = { 1, 2, 3, 5, 7 }; p.Add(temp21);

        int[] temp22 = { 1, 2, 3, 4, 5 }; p.Add(temp22);
        int[] temp23 = { 2, 3, 4, 5, 6 }; p.Add(temp23);
        int[] temp24 = { 3, 4, 5, 6, 7 }; p.Add(temp24);
        int[] temp25 = { 3, 4, 5, 6, 7 }; p.Add(temp25);
        int[] temp26 = { 1, 4, 5, 6, 7 }; p.Add(temp26);
        int[] temp27 = { 1, 2, 3, 6, 7 }; p.Add(temp27);
        int[] temp28 = { 1, 2, 3, 4, 7 }; p.Add(temp28);
        int[] temp29 = { 1, 2, 3, 4, 5 }; p.Add(temp29);
        int[] temp30 = { 2, 3, 4, 5, 6 }; p.Add(temp30);
        int[] temp31 = { 2, 3, 4, 5, 6 }; p.Add(temp31);
        int[] temp32 = { 3, 4, 5, 6, 7 }; p.Add(temp32);
        int[] temp33 = { 2, 4, 5, 6, 7 }; p.Add(temp33);
        int[] temp34 = { 2, 4, 5, 6, 7 }; p.Add(temp34);
        int[] temp35 = { 1, 2, 4, 5, 6 }; p.Add(temp35);
        int[] temp36 = { 1, 2, 3, 4, 7 }; p.Add(temp36);
        int[] temp37 = { 1, 2, 3, 4, 5 }; p.Add(temp37);
        int[] temp38 = { 1, 2, 3, 4, 5 }; p.Add(temp38);
        int[] temp39 = { 2, 3, 4, 5, 6 }; p.Add(temp39);
        int[] temp40 = { 3, 4, 5, 6, 7 }; p.Add(temp40);
        int[] temp41 = { 3, 4, 5, 6, 7 }; p.Add(temp41);
        int[] temp42 = { 1, 2, 3, 5, 7 }; p.Add(temp42);

        int[] temp43 = { 1, 2, 3, 4, 5 }; p.Add(temp43);
        int[] temp44 = { 2, 3, 4, 5, 6 }; p.Add(temp44);
        int[] temp45 = { 3, 4, 5, 6, 7 }; p.Add(temp45);
        int[] temp46 = { 3, 4, 5, 8, 7 }; p.Add(temp46);
        int[] temp47 = { 1, 4, 5, 6, 7 }; p.Add(temp47);
        int[] temp48 = { 1, 2, 3, 8, 7 }; p.Add(temp48);
        int[] temp49 = { 1, 2, 3, 4, 7 }; p.Add(temp49);
        int[] temp50 = { 1, 2, 3, 4, 5 }; p.Add(temp50);
        int[] temp51 = { 2, 3, 4, 5, 6 }; p.Add(temp51);
        int[] temp52 = { 2, 3, 4, 5, 8 }; p.Add(temp52);
        int[] temp53 = { 3, 4, 5, 6, 8 }; p.Add(temp53);
        int[] temp54 = { 2, 4, 5, 6, 7 }; p.Add(temp54);
        int[] temp55 = { 2, 4, 5, 6, 7 }; p.Add(temp55);
        int[] temp56 = { 1, 2, 4, 5, 6 }; p.Add(temp56);
        int[] temp57 = { 1, 2, 8, 4, 7 }; p.Add(temp57);
        int[] temp58 = { 1, 2, 3, 4, 8 }; p.Add(temp58);
        int[] temp59 = { 1, 2, 8, 4, 5 }; p.Add(temp59);
        int[] temp60 = { 2, 3, 4, 5, 6 }; p.Add(temp60);
        int[] temp61 = { 3, 4, 5, 6, 7 }; p.Add(temp61);
        int[] temp62 = { 3, 4, 5, 6, 7 }; p.Add(temp62);
        int[] temp63 = { 1, 2, 3, 5, 8 }; p.Add(temp63);

        int[] temp64 = { 1, 2, 8, 4, 5 }; p.Add(temp64);
        int[] temp65 = { 2, 3, 4, 5, 6 }; p.Add(temp65);
        int[] temp66 = { 3, 4, 5, 6, 7 }; p.Add(temp66);
        int[] temp67 = { 3, 4, 5, 6, 8 }; p.Add(temp67);
        int[] temp68 = { 1, 4, 5, 6, 7 }; p.Add(temp68);
        int[] temp69 = { 1, 2, 3, 8, 7 }; p.Add(temp69);
        int[] temp70 = { 1, 8, 3, 4, 7 }; p.Add(temp70);
        int[] temp71 = { 1, 2, 3, 4, 5 }; p.Add(temp71);
        int[] temp72 = { 2, 3, 4, 5, 6 }; p.Add(temp72);
        int[] temp73 = { 2, 3, 4, 5, 6 }; p.Add(temp73);
        int[] temp74 = { 3, 4, 5, 6, 7 }; p.Add(temp74);
        int[] temp75 = { 2, 4, 5, 6, 7 }; p.Add(temp75);
        int[] temp76 = { 2, 4, 5, 6, 7 }; p.Add(temp76);
        int[] temp77 = { 1, 2, 8, 5, 6 }; p.Add(temp77);
        int[] temp78 = { 1, 2, 3, 4, 7 }; p.Add(temp78);
        int[] temp79 = { 1, 2, 3, 4, 5 }; p.Add(temp79);
        int[] temp80 = { 1, 2, 3, 4, 5 }; p.Add(temp80);
        int[] temp81 = { 2, 3, 4, 5, 6 }; p.Add(temp81);
        int[] temp82 = { 3, 4, 5, 6, 8 }; p.Add(temp82);
        int[] temp83 = { 3, 4, 5, 6, 7 }; p.Add(temp83);
        int[] temp84 = { 1, 2, 3, 5, 8 }; p.Add(temp84);

        List<int> t = new List<int>();
        t.Add(1500);
        t.Add(1600);
        t.Add(1700);
        t.Add(1800);
        t.Add(2000);
        t.Add(2200);
        t.Add(2300);
        t.Add(2600);
        t.Add(2900);
        t.Add(3000);
        t.Add(3200);
        t.Add(3300);
        t.Add(3600);
        t.Add(3800);
        t.Add(4000);
        t.Add(4200);
        t.Add(4300);
        t.Add(4400);
        t.Add(4500);
        t.Add(4600);
        t.Add(4700);

        List<int> fe = new List<int>();

        fe.Add(1);
        fe.Add(1);
        fe.Add(1);
        fe.Add(2);
        fe.Add(2);
        fe.Add(2);
        fe.Add(2);
        fe.Add(2);
        fe.Add(3);
        fe.Add(3);
        fe.Add(3);
        fe.Add(3);
        fe.Add(3);
        fe.Add(3);
        fe.Add(4);
        fe.Add(4);
        fe.Add(4);
        fe.Add(4);
        fe.Add(4);
        fe.Add(4);
        fe.Add(4);

        Directory.CreateDirectory(Application.persistentDataPath + @"/DataFile");
        FileUtils f = new FileUtils();
        f.path = Application.persistentDataPath + @"/DataFile/MapData.dat";

        for (int i = 0; i < 84; i++)
        {
            Map map = new Map();
            map.Level = i + 1;
            map.LimitTime = 61f + i * 2f;

            if (i < 21)
            {
                map.TargetScore = t[i];
                map.Fruits = p[i];
                map.Freeze = fe[i];
            }
            else
            {
                map.Fruits = p[i];
                map.Freeze = 5;
                map.TargetScore = t[20] + (i - 20) * 100;

            }

            map.Stars = 0;
            if (i == 0)
            {
                map.Locked = false;
            }
            else
                map.Locked = true;
            map.Power3 = 0;
            if (i > 15)
            {
                map.Power1 = 1;
                map.Power2 = 3;

            }
            f.Maps.Add(map);
        }
        f.Save();
    }
}
