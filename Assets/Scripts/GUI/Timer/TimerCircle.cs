using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCircle : MonoBehaviour
{
    public Image circle;
    public Timer timer;
    private AudioSource audioSource;
    private float Percent
    {
        get { return timer.time / timer.startTime; }
    }
    void Awake() {
        timer = new Timer(GameSettings.instance.secondsPerRound);
        gameObject.SetActive(false);
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        timer.onTimeExpired += OnTimerEnd;
    }
    

    public void Begin() {
        timer.Start();
    }
    public void Reset() {
        
        UpdateFill();
        
    }
    void Update()
    {
        timer.Update();
        UpdateFill();
    }

    void OnTimerEnd() {
        audioSource.Play();
        GamePlay.EndRound();
    }

    void UpdateFill()
    {
        circle.fillAmount = 1 - Percent;
    }
    
}
