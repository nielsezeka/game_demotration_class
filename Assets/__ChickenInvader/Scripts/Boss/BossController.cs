using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossController : MonoBehaviour
{
    public TMP_Text hpText;
    public UnityEngine.UI.Slider theSliderHP;
    public int bossMaxHp;
    public int bossCurrentHp;
    public static BossController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    void Update()
    {
        hpText.text = bossCurrentHp + "/" + bossMaxHp;
        theSliderHP.value = bossCurrentHp;
        theSliderHP.maxValue = bossMaxHp;
    }
    public void onHitted()
    {
        if (bossCurrentHp > 0)
        {
            bossCurrentHp -= 1;
        }
    }
    public void SetHasDie()
    {

    }
}
