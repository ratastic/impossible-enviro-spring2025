using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainRot : MonoBehaviour
{
    public Vector3 rotationAxis = new Vector3(0, 1, 0);
    public float rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
