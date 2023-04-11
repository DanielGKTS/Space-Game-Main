using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{
    [SerializeField] float yawSpeed = 60f;
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float pitchSpeed = 60f;
    [SerializeField] float rollSpeed = 60f;
    [SerializeField] Slider healthBar; // reference to the health slider
    [SerializeField] float maxHealth = 10000f; // new variable for max health
    float health; // new variable for current health

    Rigidbody rigidbody;

    static float yawInput;
    static float thrustInput;
    static float pitchInput;
    static float rollInput;

    public static float YawAmount { get { return yawInput; } }
    public static float ThrustAmount { get { return thrustInput; } }
    public static float PitchAmount { get { return pitchInput; } }
    public static float RollAmount { get { return rollInput; } }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        health = maxHealth; // initialize current health to max health
        healthBar.maxValue = maxHealth; // set the max value of the health slider
        healthBar.value = health; // set the initial value of the health slider
    }

    void Update()
    {
        yawInput = Input.GetAxis("Horizontal");
        thrustInput = Input.GetAxis("Vertical");
        pitchInput = Input.GetAxis("Pitch");
        rollInput = Input.GetAxis("Roll");
    }

    void FixedUpdate()
    {
        ApplyYaw();
        ApplyThrust();
        ApplyPitch();
        ApplyRoll();
    }

    void ApplyYaw()
    {
        float yaw = yawInput * yawSpeed * Time.fixedDeltaTime;
        rigidbody.rotation *= Quaternion.Euler(0f, yaw, 0f);
    }

    void ApplyThrust()
    {
        float thrust = thrustInput * thrustSpeed * Time.fixedDeltaTime;
        Vector3 force = transform.forward * thrust;
        rigidbody.AddForce(force, ForceMode.Force);
    }

    void ApplyPitch()
    {
        float pitch = pitchInput * pitchSpeed * Time.fixedDeltaTime;
        Vector3 rotation = new Vector3(pitch, 0f, 0f);
        rigidbody.rotation *= Quaternion.Euler(rotation);
    }

    void ApplyRoll()
    {
        float roll = rollInput * rollSpeed * Time.fixedDeltaTime;
        Vector3 rotation = new Vector3(0f, 0f, -roll);
        rigidbody.rotation *= Quaternion.Euler(rotation);
    }

    // new function to reduce health when colliding with another object
    void OnCollisionEnter(Collision collision)
    {
        float damage = Random.Range(0f, 30f);
        health -= damage;
        healthBar.value = health; // update the value of the health slider
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}




