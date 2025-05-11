using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string PlayerTag;

    public GameObject door;
    public float openRot, closedRot, speed;
    public bool opening;

    public float autoCloseDelay = 2f;
    private bool isProcessing = false;

    private void Update()
    {
        Vector3 currentRot = door.transform.localEulerAngles;
        if (opening)
        {
            if(currentRot.y < openRot)
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRot, currentRot.z), speed * Time.deltaTime);
            }
        }
        else
        {
            if (currentRot.y > closedRot)
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closedRot, currentRot.z), speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Debug.Log("door opening");

            if (!opening && !isProcessing)
            {
                opening = true;
                StartCoroutine(AutoClose());
            }
        }
    }

    private IEnumerator AutoClose()
    {
        isProcessing = true;
        yield return new WaitForSeconds(autoCloseDelay);
        opening = false;
        isProcessing = false;
    }
}
