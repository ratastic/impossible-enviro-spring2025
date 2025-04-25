using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIDoorTrig : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("EnterTrig");
        }

        Debug.Log("did not play");
    }
}
