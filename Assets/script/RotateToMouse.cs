using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public static RotateToMouse Instance { get; private set; }

    [SerializeField] private float rotCamXAxisSpeed = 5f; 
    [SerializeField] private float rotCamYAxisSpeed = 3f; 
 
    private float limitMinX = -80; 
    private float limitMaxX = 50; 
 
    public float eulerAngleX; 
    public float eulerAngleY;

    public bool anglepause = true;
    public bool pause;


    private void Awake()
    {
        Instance = this;
    }

    public void CalculateRotation(float mouseX, float mouseY)
    {
        if (anglepause)
        {
            eulerAngleY += mouseX * rotCamYAxisSpeed;
            eulerAngleX -= mouseY * rotCamYAxisSpeed;
            eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);
            transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
        }
    }
    
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
 
        if (angle > 360)
        {
            angle -= 360;
        }
 
        return Mathf.Clamp(angle, min, max);
    }

    private void Update()
    {
        cursor();
    }

    void cursor()
    {
        if (pause)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
