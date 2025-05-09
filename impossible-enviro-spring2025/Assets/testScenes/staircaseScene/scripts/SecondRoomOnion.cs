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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }

        if (other.gameObject.CompareTag("green_roomTwo"))
        {
            roomOneOnion.SetActive(true);
            secondRoomOnion.SetActive(false);

            //roomOneOnion.transform.position = new Vector3(-68.17f, 1.95403f, 39.39f);
            //roomOneOnion.transform.Rotate(0f, 90.0f, 0f);
        }
    }
}
