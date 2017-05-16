using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighTriggerCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other){
        GameObject otherObject = other.gameObject;
        Ball Ball = otherObject.GetComponent<Ball>();
        Ball.SetHighTriggered();
    }
}
