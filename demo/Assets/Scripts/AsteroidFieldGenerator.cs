using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab; // Prefab of the asteroid to be generated
    public GameObject asteroidPrefab2; // Prefab of the asteroid to be generated
    public int asteroidCount; // Number of asteroids to generate
    public float asteroidRadius; // Maximum radius of the asteroid field
    public float asteroidMinScale; // Minimum scale of the asteroids
    public float asteroidMaxScale; // Maximum scale of the asteroids

    void Start()
    {
        // Generate asteroids
        for (int i = 0; i < asteroidCount; i++)
        {
            // Generate random position within the asteroid field
            Vector3 asteroidPosition = Random.insideUnitSphere * asteroidRadius;

            // Create new asteroid from prefab
            GameObject asteroid = Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);
            GameObject asteroid2 = Instantiate(asteroidPrefab2, asteroidPosition, Quaternion.identity);

            // Set asteroid scale randomly between minimum and maximum scale
            float asteroidScale = Random.Range(asteroidMinScale, asteroidMaxScale);
            asteroid.transform.localScale = new Vector3(asteroidScale, asteroidScale, asteroidScale);

            // Set asteroid rotation randomly
            asteroid.transform.rotation = Random.rotation;
            asteroid2.transform.rotation = Random.rotation;
        }
    }
}

