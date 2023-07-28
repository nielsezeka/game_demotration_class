using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserChoiceBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseRock()
    {
        GameManager.Instance.StopRollingAndShowResult(ChoiceHande.rock);
    }
    public void ChoosePaper()
    {
        GameManager.Instance.StopRollingAndShowResult(ChoiceHande.paper);
    }
    public void ChooseScrissor()
    {
        GameManager.Instance.StopRollingAndShowResult(ChoiceHande.scrissor);
    }
}
