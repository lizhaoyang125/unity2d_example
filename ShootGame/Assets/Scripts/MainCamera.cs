using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target; // The target object for the camera to follow
    public float yOffset = 3f; // The vertical offset of the camera

    // Update is called once per frame
    void Update()
    {
        // Make the camera follow the target's y position, but keep its own x and z positions
        transform.position = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
    }
}
