using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTest : MonoBehaviour {
    public Timer timer;
    
    public Image i;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(10);
        timer.onTimeExpired += print;
    }

    public void begin() {
        
        timer.Start();
    }

    void print() {
        Debug.Log("end of  time");
        //timer.onTimeExpired -= print;
    }
    // Update is called once per frame
    void Update()
    {
        timer.Update();
        i.fillAmount = 1 - timer.time / timer.startTime;
        
    }
}
