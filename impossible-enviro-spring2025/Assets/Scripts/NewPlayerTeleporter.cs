using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerTeleporter : MonoBehaviour
{
    public string PlayerTag;
    public Transform TeleportZoneObject;
    public GameObject mirror;

    private int counter = 0;

    private void Start()
    {
        mirror.SetActive(false);
    }

    private void Update()
    {
        if (counter == 3)
        {
            mirror.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Debug.Log(counter);
            counter++;
            Vector3 localOffset = transform.InverseTransformPoint(other.transform.position);
            Quaternion relativeRotation = TeleportZoneObject.rotation * Quaternion.Inverse(transform.rotation);


            other.transform.position = TeleportZoneObject.TransformPoint(localOffset);
            other.transform.rotation = TeleportZoneObject.rotation;

            FirstPersonLook lookScript = other.GetComponentInChildren<FirstPersonLook>();
            if (lookScript != null)
            {
                lookScript.ResetLook(Vector2.zero);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HallwayMirror"))
        {
            Debug.Log("changing to the next scene");
            SceneManager.LoadScene(4);
        }
    }
}