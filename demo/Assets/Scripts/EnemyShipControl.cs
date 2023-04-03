using UnityEngine;

public class EnemyShipControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float shootingRange = 10f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;

    Transform playerShip;
    Rigidbody rb;

    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move towards player ship
        Vector3 directionToPlayer = playerShip.position - transform.position;
        rb.velocity = directionToPlayer.normalized * moveSpeed;

        // Rotate towards player ship
        Vector3 directionToLook = playerShip.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToLook);
        rb.rotation = Quaternion.Slerp(rb.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);

        // Shoot at player ship if in range
        if (directionToPlayer.magnitude < shootingRange)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20f;
    }
}


