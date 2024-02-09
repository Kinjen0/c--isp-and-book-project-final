using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This should play a sound whenever an obsticle is hit by the player
public class ObsticalControler : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            audio.Play(0);
        }
    }
}
