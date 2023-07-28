using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceHande: int
{
    rock = 0,
    paper = 1,
    scrissor= 2,
}
public class HostChoiceBehavior : MonoBehaviour
{
    public UnityEngine.UI.Image hostChoiceImage;
    public Sprite rockImage;
    public Sprite paperImage;
    public Sprite scrissorImage;
    ChoiceHande currentHand = ChoiceHande.rock;
    void Start()
    {
        
    }
    public void SetSprite(ChoiceHande selection) {
        currentHand = selection;
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentHand)
        {
            case ChoiceHande.rock:
                hostChoiceImage.sprite = rockImage;
                break;
            case ChoiceHande.paper:
                hostChoiceImage.sprite = paperImage;
                break;
            case ChoiceHande.scrissor:
                hostChoiceImage.sprite = scrissorImage;
                break;
            default:
                break;
        }
    }
}
