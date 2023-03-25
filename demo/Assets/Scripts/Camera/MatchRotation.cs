using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{

    [SerializeField] Transform target;

    // takes palce after update and fixed updates 
    void LateUpdate()
    {
        transform.rotation = target.rotation;

    }
}
