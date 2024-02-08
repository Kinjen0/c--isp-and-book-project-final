using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControler : MonoBehaviour
{
    Animator animator;

    public Rigidbody body;
    public float thrust;
    public ParticleSystem exaust;

    private AudioSource rocketEffect;

    // Timers
    private float boostCooldown = 7f;
    private float boostTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        exaust.Stop();

        //body = GetComponentInParent<Rigidbody>(); // https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInParent.html

        // get the rocket sound effect
        rocketEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        boostTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && boostTimer <= 0) // https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
        {
            animator.SetBool("isBoosting", true);
            StartCoroutine(StartBoosting());
            boostTimer = boostCooldown;
        }


    }

    IEnumerator StopBoosting()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("isBoosting", false);

        Debug.Log("Boosting has ended");
        exaust.Stop();
        rocketEffect.Stop();
    }
    IEnumerator StartBoosting()
    {
        yield return new WaitForSeconds(1f);
        rocketEffect.Play();
        exaust.Play(); // Wes
        body.AddForce(transform.up *  thrust, ForceMode.Impulse);

        StartCoroutine(StopBoosting());


    }
}
