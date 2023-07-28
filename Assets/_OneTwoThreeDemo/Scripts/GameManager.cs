using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HostChoiceBehavior theHost;
    public UserChoiceBehavior theUser;
    public BetManager theBetManager;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    int index = 0;
    void Start()
    {
        StartHostRolling();
    }
    public void StartHostRolling()
    {
        theBetManager.SetBetIsRolling();
        InvokeRepeating("RandomHostChoice", 0.0f, 0.2f);
    }
    void StopHostRolling()
    {
        CancelInvoke("RandomHostChoice");
    }
    void RandomHostChoice()
    {
        index++;
        theHost.SetSprite((ChoiceHande)(index % 3));
    }
    public void StopRollingAndShowResult(ChoiceHande theChoiceOfUser)
    {
        StopHostRolling();
        int selectedFromBot = index % 3;
        int result = (int)theChoiceOfUser - selectedFromBot;
        Debug.Log("you chosse:" + (int)theChoiceOfUser +" and the host chosse" + selectedFromBot +" result:" + result);
        if ((result == 1) || (result == -2))
        {
            Debug.Log("winnnn");
            theBetManager.ShowWin();
        } else if (result == 0)
        {
            Debug.Log("drawwww");
            theBetManager.ShowDraw();
        }
        else
        {
            Debug.Log("loose");
            theBetManager.ShowLose();
        }
    }
    public void AddBetCoin(int value)
    {
        theBetManager.Add(value);
    }
    public void Clean()
    {
        theBetManager.Reset();
    }
}
