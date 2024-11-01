using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxInteract : MonoBehaviour
{
    public bool isShow;
    public static BoxInteract Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        Instance = this;
    }

    public void Interact()
    {
        if (!pauseUI.Instance.gameObject.activeSelf &&!InventoryUI.Instance.gameObject.activeSelf && !settingUI.Instance.gameObject.activeSelf){ 
            if (DiaryUI.Instance.isdiary)
            {
                if (!boxUI.Instance.gameObject.activeSelf)
                {
                    boxUI.Instance.Show();
                    RotateToMouse.Instance.anglepause = false;
                    RotateToMouse.Instance.pause = false;
                    soundManager.Instance.box1AudioSource.Play();
                }
                else
                {
                    if (!isShow)
                    { 
                        boxCloseMonster.Instance.monstershow(); 
                        player.Instance.gameObject.transform.position = new Vector3(120, 21, 49);
                        story5.Instance.startt();
                        isShow = true;
                    }
                    boxUI.Instance.Hide();
                    player.Instance.ui = false;
                    RotateToMouse.Instance.anglepause = true;
                    RotateToMouse.Instance.pause = true;
                }
            }
            else
            {
                StoryLineUI.Instance.Show();
                text.text = "시스템 : 일기를 확인해보자.";
                StartCoroutine(ss());
            }
        }
    }

    private IEnumerator ss()
    {
        yield return new WaitForSeconds(1.5f);
        StoryLineUI.Instance.Hide();
    }
}