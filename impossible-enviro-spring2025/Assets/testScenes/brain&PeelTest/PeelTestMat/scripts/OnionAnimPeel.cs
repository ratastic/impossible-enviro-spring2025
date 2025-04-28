using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionAnimPeel : MonoBehaviour
{
    public Animator animator;
    public string triggerName;

    public void PlayAnimation()
    {
        animator.SetTrigger(triggerName);
    }
}
