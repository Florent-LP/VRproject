using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private bool HighTriggered;
    private bool LowTriggered;
    private bool Dying;
    private float CreatedAt;

    private void Start(){
        HighTriggered = false;
        LowTriggered = false;
        Dying = false;
        CreatedAt = Time.time;
    }

    private void Update(){
        if (!Dying) {
          if (LowTriggered) {
              /*SphereCollider collider = GetComponent<SphereCollider>();
              collider.enabled = false;*/
              Dying = true;
              Destroy(gameObject, 1);
          }
          else if ((Time.time - CreatedAt) >= 10f)
              Destroy(gameObject, 0);
        }
    }

    public void SetHighTriggered(){
        HighTriggered = true;
    }

    public bool IsHighTriggered(){
       return HighTriggered;
    }

    public void SetLowTriggered(){
        LowTriggered = true;
    }

}
