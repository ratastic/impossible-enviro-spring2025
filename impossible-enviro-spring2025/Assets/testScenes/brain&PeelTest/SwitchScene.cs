using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public AudioSource dreamybell;
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
        if (other.gameObject.CompareTag("portkey"))
        {
            Debug.Log("triggered");
            dreamybell.Play();
            SceneManager.LoadScene("Staircase");
        }
    }
}
