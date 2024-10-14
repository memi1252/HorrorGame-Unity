using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class altarIN : MonoBehaviour
{
    public static altarIN Instance { get; private set; }

    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject mirrorbeam;
    [SerializeField] private GameObject monsterlight;
    
    Animator animator;
    private float time = 13f;
    private bool dd = false;
    public bool altar = false;
    

    private void Awake()
    {
        Instance = this;
        monster.SetActive(false);
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
            dd = true;
            }
            RotateToMouse.Instance.anglepause = false;
            player.Instance.move = false;
            RenderSettings.fogDensity = 0.03f;
            
        }
    }

    private void Update()
    {
        if (dd)
        {
            dd = true;
            time-=Time.deltaTime;
            if (time < 0)
            {
                altar = true;
                RotateToMouse.Instance.anglepause = true;
                RenderSettings.fogDensity = 0.07f;
                monsterlight.SetActive(false);
                player.Instance.move = true;
                time = 99999999999f;
            }
        }
    }

    IEnumerator ss()
    {
        yield return new WaitForSeconds(0.1f);
        player.Instance.playerAnimator.SetBool("in", false);
    }
}
