using System;
using UnityEngine;

public class blackUI : MonoBehaviour
{
    public static blackUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
