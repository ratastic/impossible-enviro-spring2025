using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToHallwayScript : MonoBehaviour
{
    public GameObject thirdOnionPlayer;
    public GameObject hallwayPlayer;

    public AudioSource staircaseSong;
    public AudioSource hallwaySong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("toHallway"))
        {
            thirdOnionPlayer.SetActive(false);
            hallwayPlayer.SetActive(true);

            staircaseSong.Stop();
            hallwaySong.Play();
        }
    }
}
