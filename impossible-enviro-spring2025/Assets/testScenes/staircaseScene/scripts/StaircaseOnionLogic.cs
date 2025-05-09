using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseOnionLogic : MonoBehaviour
{
    public GameObject staircaseOnion;
    public GameObject staircaseCam;
    public GameObject roomOneOnion;

    public GameObject roomTwoOnion;

    public GameObject finalOnion;
    
    // Start is called before the first frame update
    void Start()
    {
        staircaseOnion.transform.position = new Vector3(-2.65f, -4.86f, -2.96f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("doorOne"))
        {
            staircaseCam.SetActive(false);
            roomOneOnion.SetActive(true);
            staircaseOnion.SetActive(false);

            GameObject.FindGameObjectWithTag("green_roomOne").GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("green_roomTwo").GetComponent<BoxCollider2D>().enabled = false;
        }

        if (other.gameObject.CompareTag("doorTwo"))
        {
            roomTwoOnion.SetActive(true);
            staircaseCam.SetActive(false);
            staircaseOnion.SetActive(false);


            GameObject.FindGameObjectWithTag("blue_roomOne").GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("blue_roomTwo").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("green_roomOne").GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("green_roomTwo").GetComponent<BoxCollider2D>().enabled = true;




            //roomTwoOnion.transform.position = new Vector3(55.05f, -5.13f, -35.21f);
        }

        if (other.gameObject.CompareTag("pinkFinalDoor"))
        {
            staircaseOnion.SetActive(false);
            staircaseCam.SetActive(false);
            finalOnion.SetActive(true);
        }
    }
}
