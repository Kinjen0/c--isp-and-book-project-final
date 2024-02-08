using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wes. I used this youtube video to help me figure out how to make this work https://www.youtube.com/watch?v=bIM3VAiZHeQ
// and this one https://www.youtube.com/watch?app=desktop&v=IbiwNnOv5So

public class AsteroidSpawn : MonoBehaviour
{

    public GameObject asteroidPrefab;

    // Timer to be used later when I want them to spawn every few seconds
    private Time timeSinceLastSpawn;

    // numbers for the range, so that it can be set per level
    public int min;
    public int max;
    public int height;
    private float spawnTimer = 1f;
    private float spawnCooldown = 0f;


    // Update is called once per frame
    void Update()
    {
        // Whenever I press space, spawn an asteroid within the bounds I set for the level
        if(spawnCooldown <= 0)
        {
            Vector3 randomLocation = new Vector3(Random.Range(min, max), height, Random.Range(min, max));

            Instantiate(asteroidPrefab, randomLocation, Quaternion.identity);
            spawnCooldown = spawnTimer;
        }
        spawnCooldown -= Time.deltaTime;


    }


}
