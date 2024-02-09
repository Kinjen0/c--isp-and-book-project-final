using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
// This class is meant to control the asteroids, more specefically, it is meant to play the sound on impact, and then delete itself soon after
public class AsteroidControler : MonoBehaviour
{
    //https://pixabay.com/sound-effects/large-rocket-engine-86240/
    private AudioSource AS;

    // Get the audio source
    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        // If the object falls past the map, and or ends up underneath the map, it will eventually fall far enough to destroy itself
        if(gameObject.transform.position.y <= -20)
        {
            Destroy(this.gameObject);

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // if the colision isnt with the player destroy itself in half a second 
        if(collision.gameObject.name != "Player")
        {
            StartCoroutine(DestroyAsteroid(.5f));
        }
        else
        {
            StartCoroutine(DestroyAsteroid(1f));
        }
    }
    // Play the sound, then wait for a inputed amount of time, then destroy itself
    IEnumerator DestroyAsteroid(float time)
    {
        AS.Play();

        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
