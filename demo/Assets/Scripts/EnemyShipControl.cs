using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShipControl : MonoBehaviour
{
    [SerializeField] List<Transform> muzzles;
    [SerializeField][Range(0f, 5f)] float coolDownTime = 5f;
    [SerializeField] float forceSpeed = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float shootingRange = 10f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float minimumDistance = 5f;

    Transform playerShip;
    Rigidbody rb;

    // private float forceInput;
    private float coolDown;

    private bool CanFire
    {
        get
        {
            return coolDown <= 0f;
        }
    }

    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //forceInput = Input.GetAxis("Fire");
        coolDown -= Time.deltaTime;

    }
    void FixedUpdate()
    {
        // Check if player ship is still present
        if (playerShip == null) return;

        // Move towards player ship
        Vector3 directionToPlayer = playerShip.position - transform.position;
        if (directionToPlayer.magnitude < minimumDistance)
        {
            // Move away from player ship
            directionToPlayer = -directionToPlayer.normalized * (minimumDistance + 2.0f);
        }
        else if (directionToPlayer.magnitude < shootingRange)
        {
            // Move towards player ship but maintain minimum distance
            directionToPlayer = directionToPlayer.normalized * (directionToPlayer.magnitude - minimumDistance);
        }
        rb.velocity = directionToPlayer.normalized * moveSpeed;

        // Rotate towards player ship
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        rb.rotation = Quaternion.Slerp(rb.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);

        // Shoot at player ship if in range
        if (directionToPlayer.magnitude < shootingRange)
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        if (CanFire)
        {
            coolDown = coolDownTime;

            foreach (Transform muzzle in muzzles)
            {
                Vector3 directionToPlayer = playerShip.position - muzzle.position;
                if (directionToPlayer.magnitude < shootingRange)
                {
                    // Add some randomness to the direction of the projectile
                    float deviation = Random.Range(-5f, 5f);
                    Vector3 directionWithDeviation = Quaternion.Euler(0f, deviation, 0f) * directionToPlayer.normalized;

                    GameObject projectile = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
                    Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

                    float fire = forceSpeed;
                    Vector3 force = directionWithDeviation.normalized * fire;
                    projectileRigidbody.AddForce(force, ForceMode.Impulse);
                    Destroy(projectile, 3f);
                }
            }
        }
    }

    /*
    private void FireProjectile()
    {
        if (CanFire)
        {
            coolDown = coolDownTime;

            foreach (Transform muzzle in muzzles)
            {
                // Check if player ship is still present
                if (playerShip == null) return;

                Vector3 directionToPlayer = playerShip.position - muzzle.position;
                if (directionToPlayer.magnitude < shootingRange)
                {
                    GameObject projectile = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
                    Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                    float fire = forceSpeed;
                    Vector3 force = directionToPlayer.normalized * fire;
                    projectileRigidbody.AddForce(force, ForceMode.Impulse);
                    Destroy(projectile, 3f);
                }
            }
        }
    }
    */
}



