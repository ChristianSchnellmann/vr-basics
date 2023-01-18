using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catchable : MonoBehaviour
{
    Rigidbody rigidbody;
    public float velocityScale = 2;
    public float lifeTime = 10;

    float startTime;

    public void Launch(Vector3 direction)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = direction * velocityScale;
        rigidbody.angularVelocity = Random.onUnitSphere * velocityScale;
        startTime = Time.time;
    }

    void Update(){
        if(Time.time > startTime + lifeTime){
            Destroy(gameObject);
        }
    }

    
}
