using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLazer : MonoBehaviour
{
    public LineRenderer beam;

    // Update is called once per frame
    void Update()
    {
        // Using code from this youtube video https://www.youtube.com/watch?v=p47XrPFq1U0
        Ray ray = new Ray(transform.position, -transform.up);
        if(Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            // If we hit 
            Vector3 hitPosition = hit.point;
            beam.SetPosition(0, transform.position);
            beam.SetPosition(1, hitPosition);
        }

    }
}
