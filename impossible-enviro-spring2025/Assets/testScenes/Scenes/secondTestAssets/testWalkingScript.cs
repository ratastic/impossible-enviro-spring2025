using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWalkingScript : MonoBehaviour
{
    public float moveForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 0, moveForce);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, 0, -moveForce);
        }
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-moveForce, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(moveForce, 0, 0);
        }
    }
}
