using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fruit : MonoBehaviour
{

    // Use this for initialization
    public int fruitID;
    //fruit position on matrix
    public Vector2 positionMap;
    //fruit type
    public int type;
    //power type
    //- destroy 9 cell
    //- destroy random a row/column
    //- destroy cross
    public int FruitPower;
    public GameObject[] FruitPowerEffect;
    public GameObject[] ScoreEffects;
    public GameObject[] soundeff;
   // public int point;
    //drop speed
    public float speed;
    //fruit start
    //- selected
    //- destroy
    //- freeze
    public bool isSelected;
    public bool isDestroy;
    public bool UnFreeze;
    //basic score
    public int Score = 10;
    bool spawn = false;
    bool des = false;
    public float cd = 0;
    bool d = false;
    bool InviRenderer = false;

    public int index_ = 0;

    void Start()
    {
        if (FruitPower == -1)
            FruitPowerEffect[0].SetActive(true);
        isDestroy = false;
        isSelected = false;
    }
    /// <summary>
    /// update 
    /// - select state
    /// - destroy state
    /// - drop
    /// </summary>
    void Update()
    {
        index_ = GlobalValues.FruitMap.IndexOf(gameObject);
        speed = GetComponent<Rigidbody2D>().velocity.y;
        if (!InviRenderer)
            if (isSelected)
                Selected();
            else
                UnSelected();
        // add effect
        AddEffect(FruitPower);
        //destroy
        if (isDestroy && !des)
        {
            if (FruitPower == 1)
                Power1();
            else if (FruitPower == 2)
                Power2();
            else if (FruitPower == 3)
                Power3();
            DestroiFruit();
            des = true;
        }
        if (isDestroy)
        {
            cd += Time.deltaTime;
            rePosmap();
        }
    }
    /// <summary>
    /// destroy fruit
    /// - disable render
    /// - calculate score
    /// - add sound effect
    /// </summary>
    public void DestroiFruit()
    {
        // set position fruit above
        if (!des)
        {
            Destroy(gameObject, 0.5f);
            // hidden renders above
            InviRenderer = true;
            //show stars animation
            Scores.ScoreEffectSpawn(Score, gameObject, ScoreEffects, ScoreEffects[3]);
            //add score
            GlobalValues.Score += Score;
            //add sound
            addsoundeffect(soundeff);
            if (GlobalValues.Score < 0)
                GlobalValues.Score = 0;
        }
    }
    /// <summary>
    /// set new fruit position in  matrix
    /// </summary>
    void rePosmap()
    {
        if (cd >= 0.1f)
            if (!d)
            {
                d = true;
                fruitSpawn.DestroyListPos.Add(positionMap);
                foreach (GameObject j in GlobalValues.FruitMap)
                    if (j.GetComponent<Fruit>().positionMap.x == positionMap.x && j.transform.position.y >= transform.position.y && j.GetComponent<Fruit>().isDestroy == false)
                    {
                        j.GetComponent<Fruit>().positionMap.y -= 1;
                    }

                GlobalValues.FruitMap.RemoveAt(GlobalValues.FruitMap.IndexOf(gameObject));
            }
    }
    /// <summary>
    /// when fruit power = 1
    /// </summary>
    void Power1()
    {
        foreach (GameObject ob in GlobalValues.FruitMap)
        {
            Vector2 temp = ob.GetComponent<Fruit>().positionMap;
            if (Mathf.Abs(temp.x - positionMap.x) < 2 && Mathf.Abs(temp.y - positionMap.y) < 2 && ob.GetComponent<Fruit>().FruitPower == 0)
                ob.GetComponent<Fruit>().isDestroy = true;
        }

    }

    /// <summary>
    /// when fruit power = 2
    /// </summary>
    void Power2()
    {
        int t = Random.Range(0, 2);
        if (t == 0)
        {
            foreach (GameObject ob in GlobalValues.FruitMap)
                if (ob.GetComponent<Fruit>().positionMap.x == positionMap.x && ob.GetComponent<Fruit>().FruitPower == 0 && ob.GetComponent<Fruit>().isDestroy == false)
                    ob.GetComponent<Fruit>().isDestroy = true;
        }
        else
            foreach (GameObject ob in GlobalValues.FruitMap)
                if (ob.GetComponent<Fruit>().positionMap.y == positionMap.y && ob.GetComponent<Fruit>().FruitPower == 0 && ob.GetComponent<Fruit>().isDestroy == false)
                    ob.GetComponent<Fruit>().isDestroy = true;

    }
    /// <summary>
    /// when fruit power = 3
    /// </summary>
    void Power3()
    {
        foreach (GameObject ob in GlobalValues.FruitMap)
            if (ob.GetComponent<Fruit>().positionMap.x == positionMap.x || ob.GetComponent<Fruit>().positionMap.y == positionMap.y && ob.GetComponent<Fruit>().FruitPower == 0)
                ob.GetComponent<Fruit>().isDestroy = true;
    }
    /// <summary>
    /// add fruit power
    /// </summary>
    /// <param name="power"></param>
    void AddEffect(int power)
    {
        if (!spawn && power > 0)
        {
            EffectSpawn(gameObject, FruitPower);
            spawn = true;
        }
        if (UnFreeze)
        {
            EffectSpawn(gameObject, -1);
            UnFreeze = false;
        }

    }
    /// <summary>
    /// add effect fruit power 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="power"></param>
    void EffectSpawn(GameObject obj, int power)
    {
        int temp = 0;
        if (power != -1)
            temp = power + 2;
        else
            temp = 6;
        GameObject ObjTemp = Instantiate(FruitPowerEffect[temp],
                     new Vector3(obj.transform.position.x, obj.transform.position.y, 0.003f),
                                         FruitPowerEffect[temp].transform.rotation) as GameObject;
        ObjTemp.transform.parent = obj.transform;
        ObjTemp.transform.localScale = new Vector3(1.23f, 1.23f, 1f);
        ObjTemp.GetComponent<Animator>().enabled = true;
        if (power == -1)
            Destroy(ObjTemp, 0.5f);
    }

    void Selected()
    {

        gameObject.GetComponent<Renderer>().enabled = false;
        if (FruitPower != -1)
            FruitPowerEffect[1].SetActive(true);
        else
        {
            FruitPowerEffect[2].SetActive(true);
            FruitPowerEffect[0].SetActive(false);
        }
    }

    void UnSelected()
    {
        if (FruitPower == -1)
            FruitPowerEffect[0].SetActive(true);

        gameObject.GetComponent<Renderer>().enabled = true;

        FruitPowerEffect[1].SetActive(false);
        FruitPowerEffect[2].SetActive(false);
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "root")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * -speed * 60f / 3);
        }
        if (other.gameObject.name.Contains("fruit"))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * -speed * 60f / 3);
    }

    //add sound
    void addsoundeffect(GameObject[] sound)
    {
        if (TraverseScreenScript.isMusic)
        {
            if (FruitPower == 1)
                Destroy(Instantiate(sound[0]) as GameObject, 1.2f);
            if (FruitPower == 2)
                Destroy(Instantiate(sound[1]) as GameObject, 1.2f);
            if (FruitPower == 3)
                Destroy(Instantiate(sound[2]) as GameObject, 1.2f);
        }

    }
}
