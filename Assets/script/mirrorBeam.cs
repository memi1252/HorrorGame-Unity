using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorBeam : MonoBehaviour
{
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(currentPosition, direction);
        RaycastHit hit;
        int maxReflections = 5;
        int reflections = 0;

        while (reflections < maxReflections)
        {
            if (Physics.Raycast(ray, out hit))
            {
                // Draw the ray only up to the hit point
                Debug.DrawRay(currentPosition, direction * hit.distance, Color.red);

                // Check if the ray hits the front of the mirror
                if (hit.transform.CompareTag("Mirror") && Vector3.Dot(hit.transform.forward, -direction) > 0.9f) // Adjust the threshold as needed
                {
                    currentPosition = hit.point;
                    direction = Vector3.Reflect(direction, hit.normal);
                    ray = new Ray(currentPosition, direction);
                    reflections++;

                    Debug.Log("Hit: " + hit.transform.name);
                }
                else
                {
                    // If the ray hits the back of the mirror or a non-mirror object, stop the raycast
                    break;
                }
            }
            else
            {
                // If no hit, draw the ray to the maximum distance
                Debug.DrawRay(currentPosition, direction * 100, Color.red);
                break;
            }
        }
    }
}