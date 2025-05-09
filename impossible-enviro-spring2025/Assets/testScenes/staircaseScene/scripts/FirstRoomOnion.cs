using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomOnion : MonoBehaviour
{
    public GameObject secondRoomOnion;
    public GameObject firstRoomOnion;

    public GameObject staircaseOnion;
    public GameObject staircaseCam;

    public GameObject pinkDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blue_roomOne"))
        {
            secondRoomOnion.SetActive(true);
            firstRoomOnion.SetActive(false);
        }

        if (other.gameObject.CompareTag("green_roomOne"))
        {
            firstRoomOnion.SetActive(false);

            staircaseOnion.SetActive(true);
            staircaseOnion.transform.position = new Vector3(2.37f, 0.23f, 5.88f);
            staircaseCam.SetActive(true);

            pinkDoor.SetActive(true);

            //GameObject.FindGameObjectWithTag("staircaseOnion").SetActive(true);
            //GameObject.FindGameObjectWithTag("staircaseOnion").transform.position = new Vector3(2.37f, 0.23f, 5.88f);
        }
    }
}
