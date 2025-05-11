using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Animator animator;         
    public string triggerName = "OpenBG"; 
    public float animationDuration = 1f;    
    public Button HelpBut;
    public Image otherImage;

    public Button leftBut;
    public Button MidBut;
    public Button RightBut;

    void Start()
    {
        leftBut.gameObject.SetActive(false);
        MidBut.gameObject.SetActive(false);
        RightBut.gameObject.SetActive(false);

        HelpBut.onClick.AddListener(() => StartCoroutine(PlayAnimationThenSwitchUI()));
    }

    IEnumerator PlayAnimationThenSwitchUI()
    {
        animator.SetTrigger(triggerName);

        yield return new WaitForSeconds(animationDuration);

        HelpBut.gameObject.SetActive(false);
        otherImage.gameObject.SetActive(false);

        leftBut.gameObject.SetActive(true);
        MidBut.gameObject.SetActive(true);
        RightBut.gameObject.SetActive(true);
    }
}
