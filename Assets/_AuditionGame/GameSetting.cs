using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
