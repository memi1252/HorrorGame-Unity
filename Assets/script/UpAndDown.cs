using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    public float x;
    
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, x + Mathf.PingPong(Time.time * 0.5f, 0.2f),
            transform.position.z);
        transform.Rotate(0, 1.5f, 0);
    }
}