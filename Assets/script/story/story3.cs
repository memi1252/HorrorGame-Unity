using System.Collections;
using TMPro;
using UnityEngine;

public class story3 : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        monster.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            monster.SetActive(true);
            player.Instance.gameObject.transform.position = new Vector3(-78, 8, 150);
            player.Instance.gameObject.transform.rotation = new Quaternion(-16, 46, 0, 0);
            StartCoroutine(sto1());
            StartCoroutine(monsters());
        }
    }

    private IEnumerator monsters()
    {
        yield return new WaitForSeconds(0.4f);
        monster.SetActive(false);
    }

    private IEnumerator sto1()
    {
        yield return new WaitForSeconds(0.8f);
        StoryLineUI.Instance.Show();
        storyText.text = "주인공 : 뭐야!!!!";
        canvas.gameObject.SetActive(true);
        StartCoroutine(sto2());
    }

    private IEnumerator sto2()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 뭐지 잘못 봤나,,";
        StartCoroutine(sto3());
    }

    private IEnumerator sto3()
    {
        yield return new WaitForSeconds(1.5f);
        storyText.text = "주인공 : 무서운데 여기서 빨리 나가야겠다.";
        StartCoroutine(sto4());
    }

    private IEnumerator sto4()
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