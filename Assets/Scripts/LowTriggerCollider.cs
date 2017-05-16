using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowTriggerCollider : MonoBehaviour {

    public ScoreManager Score;

    void OnTriggerEnter(Collider other){
        GameObject otherObject = other.gameObject;
        Ball Ball = otherObject.GetComponent<Ball>();
        if (Ball.IsHighTriggered()){
            Ball.SetLowTriggered();
            Score.ScorePoint();
        }
    }
}
