using System.Collections;
using UnityEngine;

public class altarIN : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject mirrorbeam;
    [SerializeField] private GameObject monsterlight;
    [SerializeField] private GameObject light;
    public bool altar;

    private Animator animator;
    private bool dd;
    private float time = 13f;
    public static altarIN Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        monster.SetActive(false);
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
                RotateToMouse.Instance.anglepause = true;
                
                monsterlight.SetActive(false);
                player.Instance.move = false;
                light.SetActive(true);
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
                monster.SetActive(true);
                mirrorbeam.SetActive(false);
                player.Instance.h = 0;
                player.Instance.v = 0;
                dd = true;
            }

            RotateToMouse.Instance.anglepause = false;
            light.SetActive(false);
            player.Instance.move = true;
            
        }
    }

    private IEnumerator ss()
    {
        yield return new WaitForSeconds(0.1f);
        player.Instance.playerAnimator.SetBool("in", false);
    }
}