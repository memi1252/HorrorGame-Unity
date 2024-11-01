using System;
using UnityEngine;

public class AlterTutorialUI : MonoBehaviour
{
    public static AlterTutorialUI Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        
        Hide();
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            player.Instance.move = true;
            RenderSettings.fogDensity = 0.03f;
            RotateToMouse.Instance.anglepause = true;
            Hide();
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
            player.Instance.move = true;
            RenderSettings.fogDensity = 0.03f;
            RotateToMouse.Instance.anglepause = true;
            Hide();
        }
    }
}
