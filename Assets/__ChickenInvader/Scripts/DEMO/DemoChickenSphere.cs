using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DemoChickenSphere : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public TMP_Text hpxxx;
    int hp = 3;
    int currentHp = 3;

    public GameObject expotionEffect;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = hp;
        slider.value = currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHp;
        hpxxx.text = currentHp + "/" +hp;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        currentHp -= 1;
        if (currentHp == 0)
        {
            this.gameObject.SetActive(false);
            expotionEffect.SetActive(true);
        }
    }
}
