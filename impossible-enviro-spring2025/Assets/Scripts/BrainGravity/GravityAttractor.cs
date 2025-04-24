using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

//script from https://www.youtube.com/watch?v=gHeQ8Hr92P4

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10f;
    public float slerpVal = 100;
    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, slerpVal * Time.deltaTime);
    }
}
