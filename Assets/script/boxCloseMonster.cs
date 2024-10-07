using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCloseMonster : MonoBehaviour
{
    public static boxCloseMonster Instance { get; private set; }
    
    
    
    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void monstershow()
    {
        Show();
        StartCoroutine(d());
    }

    IEnumerator d()
    {
        yield return new WaitForSeconds(1f);
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
