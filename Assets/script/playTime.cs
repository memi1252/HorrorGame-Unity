using UnityEngine;

public class playTime : MonoBehaviour
{
    public float playTimes;
    public static playTime Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        playTimes += Time.deltaTime;
    }
}