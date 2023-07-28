using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoHandleTable : MonoBehaviour
{
    public GameObject content;
    public GameObject prefab;
    public DemoManageCharacter character;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i< character.parts.Length; i++)
        {
            DemoCustomCloth part = character.parts[i];
            // create object
            GameObject xxx = Instantiate(prefab);
            xxx.transform.SetParent(content.transform);

            // set tranform to display
            xxx.transform.localScale = new Vector3(1, 1, 1);
            //set text
            xxx.GetComponent<SkinSelection>().SetTextName(part.name);
            xxx.GetComponent<SkinSelection>().myCothl = part;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
