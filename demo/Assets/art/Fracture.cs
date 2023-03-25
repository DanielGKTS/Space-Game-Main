using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;

    // Call this method when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision was with a "breakable" object
        if (collision.gameObject.CompareTag("breakable"))
        {
            // Break the object
            FractureObject();
        }
    }

    public void FractureObject()
    {
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
    }
}

