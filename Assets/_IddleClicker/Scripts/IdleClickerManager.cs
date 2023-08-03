using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IdleClickerManager : MonoBehaviour
{
    int currentLevel = 0;
    public TMP_Text textLevel;
    int maxHP;
    int currentHP = 10;
    public UnityEngine.UI.Slider sliderHP;
    public GameObject[] monsters;
    // Start is called before the first frame update
    void Start()
    {
        PrepareLevel();
    }

    void PrepareLevel()
    {
        currentLevel++;
        maxHP = currentLevel * 10;
        currentHP = maxHP;
        foreach (GameObject monster in monsters)
        {
            monster.SetActive(false);
        }
        monsters[currentLevel - 1].SetActive(true);
    }
    void Update()
    {
        textLevel.text = currentLevel.ToString();
        sliderHP.maxValue = maxHP;
        sliderHP.value = currentHP;
    }
    public void OnTapFight()
    {
        this.GetComponent<SkillEffectManager>().OnHitEffect();
        currentHP -= 1;
        if (currentHP == 0)
        {
            PrepareLevel();
        }
    }
    public void OnSkillTrigered()
    {
        this.GetComponent<SkillEffectManager>().Slot1SkillActive();
        currentHP -= 2;
        if (currentHP == 0)
        {
            PrepareLevel();
        }
    }
}
