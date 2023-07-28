    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkinSelection : MonoBehaviour
{
    public Sprite selected;
    public Sprite diselected;
    public int index;
    public TMP_Text textObject;
    public UnityEngine.UI.Image selectedImage;
    public DemoCustomCloth myCothl;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetTextName(string name)
    {
        textObject.text = name;
    }
    public void Onclick()
    {
        SingetonTestManager.Instance.cloth.SetActive(false);
    }
}
