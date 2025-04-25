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

    public GameObject nextButton; 

    private bool leftClick = false;
    private bool middleClick = false;
    private bool rightClick = false;


    void Start()
        {
            nextButton.SetActive(false); 
        }

    public void Left()
        {
            animator.SetTrigger("LeftOnion");
            leftClick = true;

            AllButtonClicked();
        }

    public void Middle()
        {
            animator.SetTrigger("MidOnion");
            middleClick = true;

            AllButtonClicked();
        }

    public void Right()
        {
            animator.SetTrigger("RightOnion");
            rightClick = true;

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
        }

    public void NextButton()
    {
        BrianPickUp.SetActive(true);

        BrainAnimator.SetTrigger("BrainPick");
        //animator.SetTrigger("BrainPick");


        Invoke("ChangeScene", 5f);  //changes scene in50 sec afrwe anim finsih
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("BrainTest"); 
    }
}
