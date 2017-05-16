using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public List<BallSpawner> Spawners = null;
    private float StartTime;
    private float ElapsedTime;
    private float LastSpawn;
    private float ElapsedTimeSinceLastSpawn;
    private float MinWaitTime;
    private float MaxWaitTime;
    private float NextSpawn;
    private int RemainingTime;

    public TextMesh Counter;

    private void Start(){

        GameObject TaggedCounter = GameObject.FindGameObjectWithTag("TimerCounter");
        if (TaggedCounter == null){
            Debug.LogError(this.GetType().Name + ": No tagged counter found.");
        }
        else Counter = TaggedCounter.GetComponent<TextMesh>();

        //Definis le temps de depart
        StartTime = Time.time;
        MinWaitTime = 3;
        MaxWaitTime = 7;
        LastSpawn = StartTime;
        NextSpawn = Random.Range(MinWaitTime, MaxWaitTime);
    }

    private void Update(){
        ElapsedTime = Time.time - StartTime;
        RemainingTime = Mathf.Max((int)Mathf.Ceil(90f - ElapsedTime), 0);
        ElapsedTimeSinceLastSpawn = ElapsedTime - LastSpawn;

        if ((ElapsedTimeSinceLastSpawn > NextSpawn)&&(RemainingTime>0)) {
            SpawnAtRandomSpawner();
            LastSpawn = Time.time;
            NextSpawn = Random.Range(MinWaitTime, MaxWaitTime);
        }

        Counter.text = string.Format("{0:0}", RemainingTime);
    }

    public void SpawnAtRandomSpawner(){
        StartCoroutine(Spawners[Random.Range(0,8)].Spawn());
    }

}
