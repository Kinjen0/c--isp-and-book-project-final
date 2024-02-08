using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
public class AsteroidControler : MonoBehaviour
{
    //https://pixabay.com/sound-effects/large-rocket-engine-86240/
    private AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -20)
        {
            Destroy(this.gameObject);

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // if the colision isnt with the player destroy itself. 
        if(collision.gameObject.name != "Player")
        {
            StartCoroutine(DestroyAsteroid(.5f));
        }
        else
        {
            StartCoroutine(DestroyAsteroid(1f));
        }
    }
    IEnumerator DestroyAsteroid(float time)
    {
        AS.Play();

        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
