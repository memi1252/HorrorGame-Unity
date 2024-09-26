using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTime : MonoBehaviour
{
    public static playTime Instance { get; private set; }
    
    public float playTimes;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        playTimes += Time.deltaTime;
    }
}
