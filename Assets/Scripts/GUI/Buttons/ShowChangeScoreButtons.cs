using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChangeScoreButtons : MonoBehaviour {
    public GameObject[] objs;
    public bool state;
    public Timer timer;
    [HideInInspector]
    public float t = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
        timer = new Timer(t);
        state = true;
        timer.onTimeExpired += AutoToggle;
        Toggle();
    }

    // Update is called once per frame
    void Update()
    {
        timer.Update();
    }

    public void AutoToggle() {
        state = false;
        foreach (GameObject g in objs)
        {
            g.SetActive(state);
        }
    }
    public void Toggle() {
        state = !state;
        if(state) timer.Start(t);
        foreach (GameObject g in objs)
        {
            g.SetActive(state);
        }

        
    }
}
