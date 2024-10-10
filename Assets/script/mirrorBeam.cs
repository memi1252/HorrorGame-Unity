using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorBeam : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject mirror;

    void Start()
    {
        // Ensure the LineRenderer is reset at the start
        lineRenderer.positionCount = 0;
        mirror.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(currentPosition, direction);
        RaycastHit hit;
        int maxReflections = 4; // Set to 4 to stop after hitting the fourth mirror
        int reflections = 0;

        // List to store the positions for the LineRenderer
        List<Vector3> positions = new List<Vector3>();
        positions.Add(currentPosition);

        while (reflections < maxReflections)
        {
            if (Physics.Raycast(ray, out hit))
            {
                // Add the hit point to the positions list
                positions.Add(hit.point);

                // Check if the ray hits the front of the mirror
                if (hit.transform.CompareTag("Mirror") && Vector3.Dot(hit.transform.forward, -direction) > 0.9f)
                {
                    currentPosition = hit.point;
                    direction = Vector3.Reflect(direction, hit.normal);
                    ray = new Ray(currentPosition, direction);
                    reflections++;

                    //Debug.Log("Hit: " + hit.transform.name);
                }
                else
                {
                    // If the ray hits the back of the mirror or a non-mirror object, stop the raycast
                    break;
                }
            }
            else
            {
                // If no hit, add the maximum distance point to the positions list
                positions.Add(currentPosition + direction * 100);
                break;
            }
        }

        // Update the LineRenderer with the new positions
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());

        if (reflections == 4)
        {
            mirror.gameObject.SetActive(true);
        }
    }
}