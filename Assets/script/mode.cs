using UnityEngine;

public class mode : MonoBehaviour
{
    // 전체 화면 모드와 창 모드를 토글하는 함수
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    // 전체 화면 모드를 변경하는 함수
    public void SetFullScreenMode(FullScreenMode mode)
    {
        Screen.fullScreenMode = mode;
    }
}