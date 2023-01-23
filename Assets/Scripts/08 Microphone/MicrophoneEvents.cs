using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneEvents : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float multiplier = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = MicrophoneListener.MicLoudness;
        loudness = loudness * multiplier;
        Debug.Log(loudness);
        float particleRate = Mathf.Clamp(loudness, 0, 1000);
        particleSystem.emissionRate = particleRate;
    }
}
