using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbMovement : MonoBehaviour
{
    CharacterController characterController;
    public  List<ActionBasedController> climbingHands = new List<ActionBasedController>();
    ActionBasedController currentClimbingHand;
    LocomotionProvider locomotionProvider;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    Vector3 fallVelocity = Vector3.zero;
    void Update()
    {
        if(climbingHands.Count == 0)
        {
            if (!characterController.isGrounded)
            {

                characterController.Move(fallVelocity * Time.deltaTime);
                fallVelocity -= Vector3.up * Time.deltaTime * 9.81f;
            }
        } else
        {
            fallVelocity = Vector3.zero;
        }
    }

    public void Climb(Vector3 previousPosition, Vector3 newPosition)
    {
        Vector3 deltaPosition = newPosition - previousPosition;
        characterController.Move(transform.rotation * -deltaPosition);
    }
   

}
