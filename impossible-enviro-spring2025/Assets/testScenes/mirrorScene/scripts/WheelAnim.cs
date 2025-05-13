using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnim : MonoBehaviour
{

    public Animator animator;
    public string triggerName = "Touch"; 
    public GameObject[] objectsToActivate;

    public AudioSource audioSource;          
    public AudioClip triggerSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered!");

            if (animator != null)
            {
                animator.SetTrigger(triggerName);
            }

            if (audioSource != null && triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound);
            }

            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
