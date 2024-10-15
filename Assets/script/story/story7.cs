using System.Collections;
using TMPro;
using UnityEngine;

public class story7 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    public static story7 Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryLineUI.Instance.Show();
            storyText.text = "주인공 : 어 거울이다.";
            StartCoroutine(sto1());
        }
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 이 빛을 모든 거울에 비추면 무언가 일어날것 같은데.";
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        Hide();
        StoryLineUI.Instance.Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}