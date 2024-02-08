using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Domenica
// Fragoso Entertainment - YouTube Channel
public class Laps : MonoBehaviour
{
    // References to game objects and variables needed for lap counting
    public GameObject start;        // Start point of the race track
    public GameObject end;          // End point of the race track
    public GameObject LapCounter;   // UI element displaying lap count
    public int LapsDone;            // Number of laps completed by the player

    public int NextSceneNumber;


    Vector3 originalPos; // // The original position of the player at the start of the race


    void Start()
    {
        // Sets the player to the place where they started
        originalPos = gameObject.transform.position;

    }

    //This method is called when the script is disabled or the object is deactivated
    private void OnDisable()
    {
        transform.position = originalPos;
    }

    void Update()
    {
        //If the player falls below a certain y-coordinate, reset their position to the starting point
        if (gameObject.transform.position.y < -20f)
        {
            gameObject.transform.position = originalPos;
        }

        //If the player completes at least one lap, load the next scene
        if (LapsDone >= 3)
        {
            SceneManager.LoadScene(NextSceneNumber);
        }
    }

    // This method is called when the player's collider completes a lap
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            // Update the original position to the position of the checkpoint (Start of the track)
            originalPos = other.transform.position;
            LapsDone += 1;

            // Update the lap counter UI text
            LapCounter.GetComponent<Text>().text = "Lap Tracker: " + LapsDone;
        }
    }
}