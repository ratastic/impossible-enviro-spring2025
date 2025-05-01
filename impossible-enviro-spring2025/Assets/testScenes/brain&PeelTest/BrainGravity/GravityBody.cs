using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script from https://www.youtube.com/watch?v=gHeQ8Hr92P4

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    private Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        attractor.Attract(myTransform);
    }
}
