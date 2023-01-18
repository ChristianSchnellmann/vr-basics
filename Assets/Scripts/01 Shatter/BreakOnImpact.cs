using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BreakOnImpact : MonoBehaviour
{
    public GameObject[] shatterPieces;
    public UnityEvent onShatter;
    public float shatterVelocity = 3.5f;

    Rigidbody rigidbody;

    void Start()
    {
        TogglePieces(false);
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > shatterVelocity)
        {
            Break();
        }
    }

    void Break()
    {
        Debug.Log("Shatter object: " + gameObject.name);
        GetComponent<MeshRenderer>().enabled = false;
        onShatter.Invoke();
        TogglePieces(true);
        DestroyComponents();
    }

    void DestroyComponents()
    {
        Destroy(GetComponent<XRGrabInteractable>());
        Destroy(rigidbody);
    }

    void TogglePieces(bool b)
    {
        foreach (GameObject g in shatterPieces)
        {
            g.SetActive(b);
        }
    }
}
