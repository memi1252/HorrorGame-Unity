using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class eraser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            storyEraser.Instance.dd();
            Destroy(gameObject);
        }
    }
}
