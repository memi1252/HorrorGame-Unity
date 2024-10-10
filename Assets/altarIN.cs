using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class altarIN : MonoBehaviour
{
    Animator animator;
    private float time = 12f;
    private bool dd = false;
    

    private void Awake()
    {
        animator = player.Instance.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dd == false)
            {
            other.gameObject.transform.position = new Vector3(-27.677f, 20.148f, -307.936f);
            RotateToMouse.Instance.eulerAngleX = 0;
            RotateToMouse.Instance.eulerAngleY = 180;
            animator.SetBool("in", true);
            StartCoroutine(ss());
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
                RotateToMouse.Instance.anglepause = true;
                RenderSettings.fogDensity = 0.07f;
                player.Instance.move = true;
            }
        }
    }

    IEnumerator ss()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("in", false);
    }
}
