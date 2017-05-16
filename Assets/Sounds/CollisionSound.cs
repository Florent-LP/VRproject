using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionSound : MonoBehaviour
{
    public AudioClip sound;
    public float amplitude = 0.7f;
    public bool modulateAmp = false;
    public string collisionTag;
    AudioSource source;
    Rigidbody rbody;
    protected float lastHit = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        // Speed modulator version
        float modulator = (modulateAmp && rbody != null) ? Mathf.Clamp01(0.03f*rbody.velocity.sqrMagnitude) : 1;

        // DeltaTime modulator version
        //float modulator = modulateAmp ? Mathf.Clamp01(Time.time - lastHit) : 1;
        
        if (other.gameObject.tag == collisionTag)
            source.PlayOneShot(sound, amplitude*modulator);

        lastHit = Time.time;
    }
}