using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class near : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    
    private void OnTriggerStay(Collider other)
    {
        UI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }
}
