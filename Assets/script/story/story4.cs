using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class story4 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 어 저기 오두막이있다!!";
            StartCoroutine(sto1());
        }
    }

    IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 버려진 오두막인가??";
        StartCoroutine(sto2());
    }
    IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 잠시 저기서 쉬었다 가자!";
        StartCoroutine(sto3());
    }
    IEnumerator sto3()
    {
        yield return new WaitForSeconds(2.5f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}