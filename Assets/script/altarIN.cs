using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class altarIN : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject mirrorbeam;
    [SerializeField] private GameObject monsterlight;
    public bool altar;

    private Animator animator;
    private bool dd;
    private float time = 13f;
    public NavMeshAgent monsternav;
    public static altarIN Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        monster.SetActive(false);
        monsternav = monster.transform.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (dd)
        {
            dd = true;
            time -= Time.deltaTime;
            if (time < 0)
            {
                altar = true;
                Destroy(monsterlight);
                AlterTutorialUI.Instance.Show();
                Time.timeScale = 0;
                monsterlight.SetActive(false);
                time = 99999999999f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dd == false)
            {
                other.gameObject.transform.position = new Vector3(-27.677f, 20.148f, -307.936f);
                other.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                RotateToMouse.Instance.eulerAngleX = 0;
                RotateToMouse.Instance.eulerAngleY = 180;
                player.Instance.playerAnimator.SetBool("in", true);
                StartCoroutine(ss());
                StartCoroutine(light());
                monster.SetActive(true);
                mirrorbeam.SetActive(false);
                player.Instance.h = 0;
                player.Instance.v = 0;
                player.Instance.move = false;
                RotateToMouse.Instance.anglepause = false;
                RenderSettings.fogDensity = 0.008f;
                dd = true;
            }
        }

        if (other.CompareTag("monster"))
        {
            monsternav.speed = 4;
        }
    }

    IEnumerator light()
    {
        yield return new WaitForSeconds(10f);
        monsterlight.SetActive(true);
    }
    
    private IEnumerator ss()
    {
        yield return new WaitForSeconds(0.1f);
        player.Instance.playerAnimator.SetBool("in", false);
    }
}