using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 2;
    public Transform boardTransform;
    public float rotationStrength = 0.01f;
    Quaternion defaultWheelRotation;
    public Transform steeringWheelTransform;
    public float steeringWheelSensitivity = 0.01f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if(steeringWheelTransform != null)
            defaultWheelRotation = steeringWheelTransform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAngle = boardTransform.eulerAngles.z;
        Debug.Log(rotationAngle);
        if(rotationAngle > 180)
        {
            rotationAngle = rotationAngle - 360;
        }
        if (steeringWheelTransform != null)
            steeringWheelTransform.localRotation = Quaternion.EulerAngles(0, 0, rotationAngle * steeringWheelSensitivity) * defaultWheelRotation;

        transform.RotateAround(Vector3.up, -rotationAngle * Time.deltaTime * rotationStrength);
        characterController.Move(transform.forward * speed * Time.deltaTime);
        
    }
}
