using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float startTime;
    public float time;
    public bool start;
    public bool ended;
    public delegate void endDelegate();
    public event endDelegate onTimeExpired;
    

    public Timer(float s) {
        startTime = s;
    }

    
    public void AddTime(float t) {
        time += t;
    }
    
    public void Start() {
        start = true;
        ended = false;
        time = startTime;
    }
    public void Start(float s) {
        startTime = s;
        time = startTime;
        start = true;
        ended = false;
    }
    
    public void Update()
    {
        if (start) {
            time -= Time.deltaTime;
        }
        

        if (time <= 0 && start && !ended) {
            start = false;
            ended = true;
            onTimeExpired?.Invoke();
            
        }
    }
}
