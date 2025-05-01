using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script from https://www.youtube.com/watch?v=gHeQ8Hr92P4

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Vector3 moveDir;

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
