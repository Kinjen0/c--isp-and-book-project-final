using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

/* Wes
 * A lot of the Code came from the wheel collider docs
 * https://docs.unity3d.com/Manual/WheelColliderTutorial.html
 * Additionally, I made use of the particle system docs to create the exausts
 * https://docs.unity3d.com/ScriptReference/ParticleSystem.html
 * This class is meant to control the player, and allow for car like movement. 
 * */

public class CarControler : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public float centreOfGravityOffset = -1f;
    public int playerHealth = 10;



    // Boosting cooldown trackers
    //public float boostCooldown = 3f;
    //public float cooldownTimer;
    // Boost variables
    //Ivy
    private float boostTime = 0f;
    private float boostDuration = 2f;
    public bool isBoosting = false;
    private float originalMotorTorque;
    private float originalSteeringRange;



    // Array of the cars wheels
    WheelControl[] wheels;
    // The cars Rigidbody
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();


        // Adjust center of mass vertically, to help prevent the car from rolling
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;

        // Find all child GameObjects that have the WheelControl script attached
        wheels = GetComponentsInChildren<WheelControl>();




    }

    // Update is called once per frame
    void Update()
    {

        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        //Debug.Log(rigidBody.velocity);
        // Unity Docs
        // Calculate current speed in relation to the forward direction of the car
        // (this returns a negative number when traveling backwards)
        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);


        // Calculate how close the car is to top speed
        // as a number from zero to one
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);

        // Use that to calculate how much torque is available 
        // (zero torque at top speed)
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);


        // Ivy
        // Boost code
        if (Input.GetButtonDown("Boost") && !isBoosting)
        {
            StartBoost();
        }

        if (isBoosting)
        {
            // Check if boost has completed
            boostTime -= Time.deltaTime;
            if (boostTime <= 0f)
            {
                EndBoost();
            }
        }
    

    // calculate how much to steer 
    // (the car steers more gently at top speed)
    float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);

        // Check whether the user input is in the same direction 
        // as the car's velocity
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        foreach (WheelControl wheel in wheels)
        {
            // Error checking, It wasnt finding the wheels
            if (wheel == null)
            {
                Debug.LogError("There is a null wheelcontrol object");
            }
            // Apply steering to Wheel colliders that have "Steerable" enabled
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
            }

            if (isAccelerating)
            {
                // Apply torque to Wheel colliders that have "Motorized" enabled
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                }
                wheel.WheelCollider.brakeTorque = 0;
            }
            else
            {
                // If the user is trying to go in the opposite direction
                // apply brakes to all wheels
                wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                wheel.WheelCollider.motorTorque = 0;
            }
        }
    }



    // Ivy
    // Boost code
    // // Unity Documentation & Discussion - CompareTag, Boolean, GetButtonDown, Collision, https://discussions.unity.com/t/car-nos-boost/41018


    public void StartBoost()
    {
        isBoosting = true;
        originalMotorTorque = motorTorque;
        originalSteeringRange = steeringRange;

        // Double the force/speed
        motorTorque *= 2;
        // Half the steering ability
        steeringRange /= 2;

        boostTime = boostDuration;
    }
    // Ivy
    public void EndBoost()
    {

        isBoosting = false;
        // Reset torque
        motorTorque = originalMotorTorque;
        // Reset steering
        steeringRange = originalSteeringRange; // Reset steering range
    }

    // Ivy
    // Boost conditions for enemy effect
    public void EnemyCollision(Collider other)
    {
        // If the enemy is collided with while boosting, eliminate the enemy
        if (isBoosting)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
        }
    }

}
