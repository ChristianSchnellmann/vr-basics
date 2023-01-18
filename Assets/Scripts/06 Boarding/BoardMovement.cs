using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 2;
    public Transform boardTransform;
    public float rotationStrength = 0.01f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
        transform.RotateAround(Vector3.up, -rotationAngle * Time.deltaTime * rotationStrength);
        characterController.Move(transform.forward * speed * Time.deltaTime);
        
    }
}
