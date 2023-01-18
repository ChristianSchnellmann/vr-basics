using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Charge : MonoBehaviour
{
    public XRBaseControllerInteractor controller1;
    public XRBaseControllerInteractor controller2;
    public Material handMaterial;
    float energy = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceBetweenHands = Vector3.Distance(controller1.transform.position, controller2.transform.position);

        if(distanceBetweenHands < 0.2f)
        {
            energy += Time.deltaTime / 5f;
        } else
        {
            energy -= Time.deltaTime * 5;
        }
        energy = Mathf.Clamp01(energy);


        handMaterial.SetColor("_EmissionColor", Color.white * energy * 5);
        if (energy > 0.2f)
        {
            Vibrate();
        }
        
    }

    void Vibrate()
    {
        controller1.SendHapticImpulse(energy, Time.deltaTime * 2);
        controller2.SendHapticImpulse(energy, Time.deltaTime * 2);
    }
}
