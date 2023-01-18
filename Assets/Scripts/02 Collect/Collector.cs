using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{
    public TextMeshPro text;
    int count = 0;

    private void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable = other.GetComponent<Collectable>();
        if(collectable != null)
        {
            count++;
            UpdateText();
            collectable.onCollect.Invoke();
            Destroy(other.gameObject);
        }
    }

    void UpdateText()
    {
        if(text == null)
            return;
        text.text = count + "";
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
