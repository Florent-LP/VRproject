using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int Score;
    public TextMesh Counter;

    private void Start(){
        Score = 0;
        GameObject TaggedCounter = GameObject.FindGameObjectWithTag("ScoreCounter");
        if (TaggedCounter == null){
            Debug.LogError(this.GetType().Name + ": No tagged counter found.");
        }
        else Counter = TaggedCounter.GetComponent<TextMesh>();
    }

    public void ScorePoint(){
        Score++;
        Debug.Log(Score);
    }

    private void Update(){
       Counter.text = Score.ToString();
    }

}
