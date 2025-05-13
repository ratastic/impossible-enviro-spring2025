using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonOnion : MonoBehaviour
{
    public Animator animator;
    public Animator BrainAnimator;
    public GameObject BrianPickUp;

    public Button leftButton;
    public Button middleButton;
    public Button rightButton;

    public GameObject[] allButtons; 

    public GameObject nextButton;
    public GameObject nextImage;

    private bool leftClick = false;
    private bool middleClick = false;
    private bool rightClick = false;

    void Start()
    {
        nextButton.SetActive(false);
        nextImage.SetActive(false);
    }

    public void Left()
    {
        animator.SetTrigger("LeftOnion");
        leftClick = true;

        // Hide all buttons immediately
        foreach (GameObject btn in allButtons)
        {
            btn.SetActive(false);
        }

        // Permanently disable this button
        leftButton.interactable = false;

        // Optionally reactivate others
        StartCoroutine(ReactivateUnclickedButtons(2.5f));

        AllButtonClicked();
    }

    public void Middle()
    {
        animator.SetTrigger("MidOnion");
        middleClick = true;

        foreach (GameObject btn in allButtons)
        {
            btn.SetActive(false);
        }

        middleButton.interactable = false;

        StartCoroutine(ReactivateUnclickedButtons(2.5f));

        AllButtonClicked();
    }

    public void Right()
    {
        animator.SetTrigger("RightOnion");
        rightClick = true;

        foreach (GameObject btn in allButtons)
        {
            btn.SetActive(false);
        }

        rightButton.interactable = false;

        StartCoroutine(ReactivateUnclickedButtons(2.5f));

        AllButtonClicked();
    }

    private void AllButtonClicked()
    {
        if (leftClick && middleClick && rightClick)
        {
            StartCoroutine(ButtonDelay(5f));
        }
    }

    private IEnumerator ButtonDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        nextButton.SetActive(true);
        nextImage.SetActive(true);
    }

    private IEnumerator ReactivateUnclickedButtons(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!leftClick) leftButton.gameObject.SetActive(true);
        if (!middleClick) middleButton.gameObject.SetActive(true);
        if (!rightClick) rightButton.gameObject.SetActive(true);
    }

    public void NextButton()
    {
        nextButton.SetActive(false);
        nextImage.SetActive(false);

        BrianPickUp.SetActive(true);
        BrainAnimator.SetTrigger("BrainPick");

        Invoke("ChangeScene", 7.5f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("BrainTest");
    }
}
