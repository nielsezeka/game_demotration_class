using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BetManager : MonoBehaviour
{
    public int currentBetValue = 10;
    public int currentUserCoin = 2000000;
    public TMP_Text betText;
    public TMP_Text userCoinText;
    public TMP_Text winCoinText;
    public TMP_Text loseCoinText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject drawPanel;
    void Update()
    {
        betText.text = "Bet: " + currentBetValue.ToString() + " $";
        userCoinText.text = currentUserCoin.ToString() + " $";
        winCoinText.text = "You win: "+ currentBetValue.ToString() + " $";
        loseCoinText.text = "You lose: " + currentBetValue.ToString() + " $";
    }
    public void Add(int coin)
    {
        currentBetValue += coin;
    }
    public void Reset()
    {
        currentBetValue = 10;
    }
    public void ShowWin()
    {
        currentUserCoin += currentBetValue;
        winPanel.SetActive(true);
    }
    public void ShowDraw()
    {
        drawPanel.SetActive(true);
    }
    public void ShowLose()
    {
        losePanel.SetActive(true);
        currentUserCoin -= currentBetValue;
    }
    public void SetBetIsRolling()
    {
        winPanel.SetActive(false);
        drawPanel.SetActive(false);
        losePanel.SetActive(false);
    }
}
