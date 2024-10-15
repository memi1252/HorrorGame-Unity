using UnityEngine;

public class itemManager : MonoBehaviour
{
    public GameObject[] item;
    public static itemManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
}