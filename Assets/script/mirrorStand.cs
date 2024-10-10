using System.Collections.Generic;
using UnityEngine;

public class mirrorStandInteract : MonoBehaviour
{
    public void Interact()
    {
        RotateBy90Degrees();
    }
    private void RotateBy90Degrees()
    {
        transform.Rotate(0, 90, 0);
    }
}