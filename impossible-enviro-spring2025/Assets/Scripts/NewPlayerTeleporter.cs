using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerTeleporter : MonoBehaviour
{
    public string PlayerTag;
    public Transform TeleportZoneObject;

    private int counter;

    private void Update()
    {
        if (counter == 3)
        {
            Debug.Log("changing to the next scene");
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

}