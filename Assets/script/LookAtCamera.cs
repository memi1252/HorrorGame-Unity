using System;
using Tripolygon.UModelerX.Runtime;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public static LookAtCamera Instance { get; private set; }

    [SerializeField] private Mode mode;
    [SerializeField] public GameObject monster1 = null;
    [SerializeField] public GameObject monster2 = null;
    

    private void Awake()
    {
        Instance = this;
    }


    private void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                var dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
            case Mode.LookATMonster:
                transform.LookAt(monster1.transform);
                break;
        }
    }


    private enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
        LookATMonster
    }
}