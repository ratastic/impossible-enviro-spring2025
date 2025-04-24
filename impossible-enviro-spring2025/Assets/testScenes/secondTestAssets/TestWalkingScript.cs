using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWalkingScript : MonoBehaviour
{
    public float moveForce = 1f;
    public bool move3d = true;
    public bool move2d = false;

    public GameObject cam3d;
    public GameObject cam2d;

    void Start()
    {
        cam3d.SetActive(true);
        cam2d.SetActive(false);
    }

    void Update()
    {
        if (move3d == true) 
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

        if (move2d == true)
        {
            if (Input.GetKey("a") || Input.GetKey("s"))
            {
                transform.position += new Vector3(0, 0, -moveForce);
            }
            if (Input.GetKey("d") || Input.GetKey("w"))
            {
                transform.position += new Vector3(0, 0, moveForce);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("camSwitchTrigger"))
        {
            move3d = !move3d;
            move2d = !move2d;

            cam3d.SetActive(move3d);
            cam2d.SetActive(move2d);
        }
    }
}
