using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<Transform> muzzles;
    [SerializeField][Range(0f, 5f)] float coolDownTime = 5f;
    [SerializeField] float forceSpeed = 100f;
    [SerializeField] float dampeningFactor = 0.95f;
    [SerializeField] float damage = 10f;

    private float forceInput;
    private float coolDown;
    private Rigidbody rigidbody;

    private bool CanFire
    {
        get
        {
            return coolDown <= 0f;
        }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        forceInput = Input.GetAxis("Fire");
        coolDown -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        FireProjectile();
        ApplyDampening();
    }

    private void FireProjectile()
    {
        if (CanFire && forceInput > 0f)
        {
            coolDown = coolDownTime;

            foreach (Transform muzzle in muzzles)
            {
                RaycastHit Objective;
                if (Physics.Raycast(muzzle.position, muzzle.forward, out Objective))
                {
                    HealthBar healthBar = Objective.collider.GetComponent<HealthBar>();
                    if (healthBar != null)
                    {
                        float damageAmount = forceInput * forceSpeed * damage * Objective.distance;
                        healthBar.TakeDamage(damageAmount);
                    }
                }
            }
        }
    }

    private void ApplyDampening()
    {
        rigidbody.velocity *= dampeningFactor;
        rigidbody.angularVelocity *= dampeningFactor;
    }

    public float ForceAmount
    {
        get { return forceInput; }
    }
}






