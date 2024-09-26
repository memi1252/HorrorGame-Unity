using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public static flash Instance { get; private set; }

    [SerializeField] private GameObject light;
    
    public bool pickUpFlash = false;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (pauseUI.Instance.pauseUIpasue == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (light.activeSelf == true)
                {
                    light.SetActive(false);
                }
                else
                {
                    light.SetActive(true);
                }
            }
        }
    }
}
