using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject dieEffect;
    public GameObject displayerMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossController.Instance.bossCurrentHp == 0)
        {
            BossController.Instance.SetHasDie();
            dieEffect.SetActive(true);
            displayerMesh.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        BossController.Instance.onHitted();
    }
    private void OnCollisionEnter(Collision collision)
    {
        BossController.Instance.onHitted();
    }
}
