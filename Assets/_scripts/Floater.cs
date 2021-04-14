using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {

    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    public bool worldSpace = false;

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis

        if (worldSpace == true)
        {
            transform.Rotate(new Vector3(Time.deltaTime * degreesPerSecond * x, Time.deltaTime * degreesPerSecond * y, Time.deltaTime * degreesPerSecond * z), Space.World);
        }
        else
        {
            transform.Rotate(new Vector3(Time.deltaTime * degreesPerSecond * x, Time.deltaTime * degreesPerSecond * y, Time.deltaTime * degreesPerSecond * z), Space.Self);
        }

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
