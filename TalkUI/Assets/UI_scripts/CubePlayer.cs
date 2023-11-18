using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 90;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
    public void ChangeSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
