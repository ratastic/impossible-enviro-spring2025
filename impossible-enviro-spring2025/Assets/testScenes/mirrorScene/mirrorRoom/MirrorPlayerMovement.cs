using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;


    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;


    private float rotationX = 0f;

    public Camera playerCamera;

    public float jumping = 5f;
    public Rigidbody rb;

    private bool onTheGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, 0, -moveSpeed);
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey("space") && onTheGround)
        {
            rb.AddForce(Vector3.up * jumping, ForceMode.Impulse);
            onTheGround = false;
        }

        //mous camer movenemnt
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); // Prevent camera from flipping over
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
        }
    }

}
