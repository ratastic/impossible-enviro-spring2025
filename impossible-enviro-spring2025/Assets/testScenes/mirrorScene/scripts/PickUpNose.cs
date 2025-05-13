using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNose : MonoBehaviour
{

    public Animator animator;
    public string triggerName = "PlayAnim";
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(triggerName);
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
