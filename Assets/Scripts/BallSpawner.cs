using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallSpawner : MonoBehaviour {
  
    public Vector3 Position;
    public Quaternion Rotation;
    public GameObject Ball;

    private AudioSource source = null;
    public AudioClip sound = null;
    public float amplitude = 0.7f;
    public float soundDelay = -1;

    private void Start(){
        Position = transform.position;
        Rotation = transform.rotation;

        source = GetComponent<AudioSource>();
    }

    public IEnumerator Spawn(){
      if (soundDelay > 0 && source != null && sound != null) {
        source.PlayOneShot(sound, amplitude);
        yield return new WaitForSeconds(soundDelay);
      }

      GameObject spawnedBall = Instantiate(Ball, Position, Rotation);
      spawnedBall.GetComponent<Rigidbody>().AddForce(new Vector3(-Position.x,7,-Position.z).normalized * 800);
    }
}
