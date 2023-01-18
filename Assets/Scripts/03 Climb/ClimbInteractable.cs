using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    ClimbMovement climbMovement;
    ActionBasedController currentController;
    Vector3 previousPosition;

    private void Awake()
    {
        climbMovement = FindObjectOfType<ClimbMovement>();
        base.Awake();
    }

    override protected void OnSelectEntered(XRBaseInteractor interactor){
        base.OnSelectEntered(interactor);
        if(interactor is XRDirectInteractor){
            climbMovement.climbingHands.Insert(0, interactor.GetComponent<ActionBasedController>());
            currentController = interactor.GetComponent<ActionBasedController>();
            previousPosition = currentController.transform.position;

        } 
    }

    private void Update()
    {
        if (currentController != null)
        {
            climbMovement.Climb(previousPosition, currentController.transform.position);
            previousPosition = currentController.transform.position;

        }
    }

    override protected void  OnSelectExited(XRBaseInteractor interactor){
        base.OnSelectExited(interactor);

        if (interactor is XRDirectInteractor)
        {
            climbMovement.climbingHands.Remove(interactor.GetComponent<ActionBasedController>());
            currentController = null;
        }
    }
}
