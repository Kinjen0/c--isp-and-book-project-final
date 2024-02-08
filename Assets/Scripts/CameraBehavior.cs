using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Wes
// Code came from the textbook
public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);

    private Transform target;
    // First we will get the transform of the gameoject called player
    void Start()
    {
        target = GameObject.Find("Player").transform;

    }
    // Then, using late update, we will move the camera into position using the cam offset, then we will make it look at the player
    private void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
