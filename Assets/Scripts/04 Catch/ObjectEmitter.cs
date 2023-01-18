using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEmitter : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        InvokeRepeating("Emit", 1, 2);   
    }

    // Update is called once per frame
    void Emit()
    {
        Vector3 position = transform.position + Random.onUnitSphere;
        Quaternion rotation = Quaternion.LookRotation(Vector3.back);
        GameObject gameObject = Instantiate(prefab, position, rotation);
        Catchable catchable = gameObject.GetComponent<Catchable>();
        catchable.Launch(transform.forward);
        
    }
}
