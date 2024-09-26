using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public static itemManager Instance { get; private set; }

    public GameObject[] item;
    
    
    private void Awake()
    {
        Instance = this;
    }
}
