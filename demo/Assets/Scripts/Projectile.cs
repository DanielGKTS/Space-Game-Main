using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class Projectile : MonoBehaviour
{
    [SerializeField][Range(5000f, 25000f)] float _laucnhForce = 10000f;
   // [SerializeField][Range(10, 1000)] int _damage = 100;


    [SerializeField][Range(2f, 10f)] float _range = 5f;


    bool OutOfFuel
    {
        get
        {
            _duration -= Time.deltaTime;
            return _duration <= 0f;
        }
    }

    Rigidbody _rigidbody;

    float _duration;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void onEnable()
    {
        _rigidbody.AddForce(_laucnhForce * transform.forward);
        _duration = _range;

    }

    void update()
    {
        if (OutOfFuel) Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Projectile collided with {collision.collider.name}");
    }

}
