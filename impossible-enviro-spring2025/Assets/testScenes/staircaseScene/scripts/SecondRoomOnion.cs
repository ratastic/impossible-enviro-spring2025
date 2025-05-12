using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoomOnion : MonoBehaviour
{
    public GameObject secondRoomOnion;
    public GameObject staircaseOnion;
    public GameObject staircaseCam;


    public Transform staircaseOnionPos;

    public GameObject roomOneOnion;

    public GameObject mainBlueDoor;
    public GameObject mainGreenDoor;
    public GameObject loo;

    public GameObject jackNBoxText;
    public GameObject jackNBoxDoll;
    public GameObject miniDeskText;
    public GameObject clownToysText;

    private bool dollTriggered = false;
    private int triggerNum = 0;

    public FirstRoomOnion firstRoomOnion;
    // Start is called before the first frame update
    void Start()
    {
        jackNBoxText.SetActive(false);
        miniDeskText.SetActive(false);
        clownToysText.SetActive(false);
        jackNBoxDoll.SetActive(false);
        loo.SetActive(false);
    }
    private void Update()
    {
        if (triggerNum == 3) loo.SetActive(true);
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jackNBox"))
        {
            Debug.Log("jack collided");
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("blue_roomTwo"))
        {
            Debug.Log("collision detected");
            secondRoomOnion.SetActive(false);
            staircaseOnion.SetActive(true);
            staircaseCam.SetActive(true);

            staircaseOnionPos.transform.position = new Vector3(-1.795f, -0.015f, 5.14f);
            GameObject.FindGameObjectWithTag("blue_roomTwo").GetComponent<BoxCollider2D>().enabled = false;

            mainBlueDoor.SetActive(true);
            mainGreenDoor.SetActive(true);

            int randomIndex = Random.Range(0, firstRoomOnion.fartSounds.Length);
            firstRoomOnion.fartSounds[randomIndex].Play();
        }

        if (other.gameObject.CompareTag("green_roomTwo")) //toilet
        {
            roomOneOnion.SetActive(true);
            secondRoomOnion.SetActive(false);

            //roomOneOnion.transform.position = new Vector3(-68.17f, 1.95403f, 39.39f);
            //roomOneOnion.transform.Rotate(0f, 90.0f, 0f);

            int randomIndex = Random.Range(0, firstRoomOnion.fartSounds.Length);
            firstRoomOnion.fartSounds[randomIndex].Play();
        }

        if (other.gameObject.CompareTag("jackNBox"))
        {
            jackNBoxText.SetActive(true);
            triggerNum++;
            if (!dollTriggered)
            {
                jackNBoxDoll.SetActive(true);
                dollTriggered = !dollTriggered;
            }
        }

        if (other.gameObject.CompareTag("miniDesk"))
        {
            triggerNum++;
            miniDeskText.SetActive(true);
        }

        if (other.gameObject.CompareTag("clownToys"))
        {
            clownToysText.SetActive(true);
            triggerNum++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jackNBox"))
        {
            jackNBoxText.SetActive(false);
        }

        if (collision.gameObject.CompareTag("miniDesk"))
        {
            miniDeskText.SetActive(false);
        }

        if (collision.gameObject.CompareTag("clownToys"))
        {
            clownToysText.SetActive(false);
        }
    }
}
