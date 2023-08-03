using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour
{
    public GameObject effectPositionHolder;
    public GameObject slot1Prefab;
    public GameObject smashPrefab;
    public GameObject skillTextPrefab;
    void Start()
    {
        
    }

    public void Slot1SkillActive()
    {
       GameObject effect = Instantiate(slot1Prefab);
       effect.transform.SetParent(effectPositionHolder.transform.parent);
        GameObject skillText = Instantiate(skillTextPrefab);
        skillText.transform.SetParent(effectPositionHolder.transform.parent);
    }
    public void OnHitEffect()
    {
        GameObject effect = Instantiate(smashPrefab);
        effect.transform.SetParent(effectPositionHolder.transform.parent);
    }
}
