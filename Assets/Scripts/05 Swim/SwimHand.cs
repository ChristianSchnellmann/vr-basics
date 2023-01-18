using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SwimHand : MonoBehaviour
{

    public InputActionReference swimAction;
    public float easing = 0.6f;
    public float downOffset = 0.1f;

    Vector3 lastSwimPosition;
    CharacterController characterController;
    Transform cameraTransform;

    Vector3 velocity;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        characterController = GetComponentInParent<CharacterController>();
        swimAction.action.started += SwimMovementStart;
        swimAction.action.canceled += SwimMovementDone;
    }

    void SwimMovementStart(InputAction.CallbackContext obj)
    {
        Vector3 controllerLocalPosition = WorldToRigPosition(transform.position);
        lastSwimPosition = controllerLocalPosition;
        pull = true;
    }

    bool pull = false;

    private void Update()
    {

        characterController.Move(velocity * Time.deltaTime);
        velocity *= 1 - Time.deltaTime * easing;

        if (!pull)
            return;
        Vector3 controllerLocalPosition = WorldToRigPosition(transform.position);
        Vector3 deltaPosition = controllerLocalPosition - lastSwimPosition;
        deltaPosition.y += downOffset * Time.deltaTime;
        Vector3 motion = characterController.transform.TransformDirection(deltaPosition);
        velocity -= motion;
        lastSwimPosition = controllerLocalPosition;
    }


    Vector3 WorldToRigPosition(Vector3 worldPosition)
    {
        return characterController.transform.InverseTransformPoint(worldPosition);
    }



    void SwimMovementDone(InputAction.CallbackContext obj)
    {
        pull = false;
    }

}
