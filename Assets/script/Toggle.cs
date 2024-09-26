using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
    
    // 전체 화면 모드를 변경하는 함수
    public void SetFullScreenMode(FullScreenMode mode)
    {
        Screen.fullScreenMode = mode;
    }
}
