using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate around the Z-axis
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}

