using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Wes
 * all of the Code came from the wheel collider docs
 * https://docs.unity3d.com/Manual/WheelColliderTutorial.html
 * */


public class WheelControl : MonoBehaviour
{
    public Transform wheelModel;

    [HideInInspector] public WheelCollider WheelCollider;

    // Two properies that we can set to decide if a wheel is steerable or motorized
    public bool steerable;
    public bool motorized;

    Vector3 position;
    Quaternion rotation;

    private void Start()
    {
        // Get the collider component from the object
        WheelCollider = GetComponent<WheelCollider>();
    }

    void Update()
    {
        // Get the Wheel collider's world pose values and
        // use them to set the wheel model's position and rotation
        WheelCollider.GetWorldPose(out position, out rotation);
        wheelModel.transform.position = position;
        wheelModel.transform.rotation = rotation;
    }
}
