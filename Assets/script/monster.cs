using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class monster : MonoBehaviour
{
    [SerializeField] private GameObject playerDiePos;
    
    public Transform target;

    private NavMeshAgent nmAgent;
    private Animator animator;
    private bool die = false;

    private void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (die == true)
        {
            
        }
        else
        {
            nmAgent.SetDestination(target.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.Instance.move = false;
            RotateToMouse.Instance.anglepause = false;
            playerDiePos.SetActive(true);
            die = true;
            player.Instance.die = true;
            Debug.Log("die");
            Destroy(gameObject);
        }
    }
}
