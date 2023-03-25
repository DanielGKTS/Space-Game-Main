using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShipControl; 

public class CockpitAnimations : MonoBehaviour
{
    [SerializeField] Transform joystick;



    [SerializeField] Vector3 _joystickRange = Vector3.zero;

    [SerializeField]
    List<Transform> _throttles;

    [SerializeField]
    float throttleRange = 35f;



    // Update is called once per frame

    
    void Update()
    {
        joystick.localRotation = Quaternion.Euler(

            ShipControl.PitchAmount * _joystickRange.x,
            ShipControl.YawAmount * _joystickRange.y,
            ShipControl.RollAmount * _joystickRange.z



            );

        Vector3 throttleRotation = _throttles[0].localRotation.eulerAngles;
        throttleRotation.x = ShipControl.ThrustAmount * throttleRange;

        foreach (Transform throttle in _throttles)
        {
            throttle.localRotation = Quaternion.Euler(throttleRotation); 
        }



    }
    
}
