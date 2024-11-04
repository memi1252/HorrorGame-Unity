using System;
using UnityEngine;

public class carmove : MonoBehaviour
{
    public static carmove Instance { get; private set; }
    
    public bool iscar;
    public float speed = 5;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (iscar)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            soundManager.Instance.walkAudioSource.Stop();
            soundManager.Instance.runAudioSource.Stop();
        }
    }
}
