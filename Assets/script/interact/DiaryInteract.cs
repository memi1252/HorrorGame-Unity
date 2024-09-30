using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteract : MonoBehaviour
{
    public static DiaryInteract Instance { get; private set; }

    public bool interact;
    
    private void Awake()
    {
        Instance = this;
    }


    public void Interact()
    {
        if (DiaryUI.Instance.gameObject.activeSelf)
        {
            DiaryUI.Instance.Hide();
            Time.timeScale = 1;
            RotateToMouse.Instance.anglepause = true;
            interact = false;
        }
        else
        {
            DiaryUI.Instance.Show();
            Time.timeScale = 0;
            RotateToMouse.Instance.anglepause = false;
            interact = true;
        }
    }
}
