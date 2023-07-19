using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum GameUIState
{
    startMenu,
    skinSelection,
}
public class ManageSkinManager : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject skinPanel;
    // Start is called before the first frame update
    void Start()
    {
        OpenGameMenu();
    }


    public void OpenSkinSelection()
    {
        gamePanel.SetActive(false);
        skinPanel.SetActive(true);
    }
    public void OpenGameMenu()
    {
        gamePanel.SetActive(true);
        skinPanel.SetActive(false);
    }
}
