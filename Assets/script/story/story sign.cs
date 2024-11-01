using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class storysign : MonoBehaviour
{
    public static storysign Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI storyText;

    public bool esteregg;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 이 산에 뭔가 있나?";
            esteregg = true;
            StartCoroutine(sto1());
            StartCoroutine(esteregg1());
        }
    }
    
    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }
    
    private IEnumerator esteregg1()
    {
        yield return new WaitForSeconds(6f);
        esteregg = false;
    }
}
