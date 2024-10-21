using System.Collections;
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
        player.Instance.gameObject.GetComponent<LookAtCamera>().enabled = true;
        RotateToMouse.Instance.anglepause = false;
        RotateToMouse.Instance.pause = false;
        player.Instance.ui = true;
        player.Instance.move = false;
        StartCoroutine(d());
    }

    private IEnumerator d()
    {
        yield return new WaitForSeconds(0.8f);
        player.Instance.gameObject.GetComponent<LookAtCamera>().monster1 =
            player.Instance.gameObject.GetComponent<LookAtCamera>().monster2;
        player.Instance.gameObject.GetComponent<LookAtCamera>().enabled = false;
        RotateToMouse.Instance.anglepause = true;
        RotateToMouse.Instance.pause = true;
        player.Instance.ui = false;
        player.Instance.move = true;
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