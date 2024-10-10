using System.Collections.Generic;
using UnityEngine;

public class mirrorStandInteract : MonoBehaviour
{
    public void Interact()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, +90, 0);
    }
}