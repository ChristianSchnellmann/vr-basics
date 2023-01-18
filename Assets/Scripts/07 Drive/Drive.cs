using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Drive : MonoBehaviour
{
    CharacterController characterController;
    public InputActionReference steerAction;
    float speed = 1;
    public float easing = 1;
    public float turningSpeed = 1;
    public float speedMultiplier = 5;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        steerAction.action.performed += SteerHandler;
    }

    public void SteerHandler(InputAction.CallbackContext c)
    {
        Vector2 input = c.ReadValue<Vector2>();
        float newSpeed = input.y;
        speed = (1 - Time.deltaTime * easing) * speed + Time.deltaTime * easing * newSpeed;
        transform.RotateAround(Vector3.up, input.x * Time.deltaTime * turningSpeed * speed);
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(transform.forward * speed * Time.deltaTime * speedMultiplier);

    }
}
