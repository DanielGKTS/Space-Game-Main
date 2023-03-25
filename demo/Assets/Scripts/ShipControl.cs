using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour
{
    [SerializeField] float yawSpeed = 60f;
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float pitchSpeed = 60f;
    [SerializeField] float rollSpeed = 60f;

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
}



