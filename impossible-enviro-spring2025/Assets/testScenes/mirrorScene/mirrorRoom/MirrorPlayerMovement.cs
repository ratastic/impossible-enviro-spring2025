using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumping = 5f;


    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;
    private float rotationX = 0f;

    public Camera playerCamera;
    public Rigidbody rb;

    private bool onTheGround = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();


        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {

    
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
    transform.Rotate(Vector3.up* mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;
    rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);



        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // stop any upward/downward speed
    rb.AddForce(Vector3.up* jumping, ForceMode.Impulse);
            onTheGround = false;
        }
    }


    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D keys
        float moveZ = Input.GetAxis("Vertical");   // W/S keys
        Vector3 movement = transform.forward * moveZ + transform.right * moveX;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
        }

       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("frontDoor"))
        {
            Animator doorAnimator = other.GetComponent<Animator>();
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("FrontDoor");
            }
        }

        if (other.CompareTag("LDoor"))
        {
            Animator doorAnimator = other.GetComponent<Animator>();
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("leftDoor");
            }
        }

        if (other.CompareTag("RDoor"))
        {
            Animator doorAnimator = other.GetComponent<Animator>();
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("rightDoor");
            }
        }
        
    }
}
