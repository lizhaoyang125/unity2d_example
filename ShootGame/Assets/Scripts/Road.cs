using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Rod : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Map; // The object you want to instantiate
    void Start()
    {
        Instantiate(Map, new Vector3(0, 10, 0), Quaternion.identity);
        Instantiate(Map, new Vector3(0, -10, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
