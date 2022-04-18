using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public GameObject Timer;
    public GameObject Scheme;
    public GameObject LastWordScreen;

    public delegate void GUIEvent();

    public event GUIEvent onTimerEnded;

    public static GUIManager instance;
    public void Start() {
        instance = this;
        LastWordScreen.SetActive(false);
        
    }
    public void ShowTimer()
    {
        Scheme.SetActive(false);
        Timer.SetActive(true);
    }
    public void ShowScheme()
    {
        Scheme.SetActive(true);
        Timer.SetActive(false);
        LastWordScreen.SetActive(false);
    }

    
    public void EndRound()
    {
        LastWordScreen.SetActive(true);
        onTimerEnded?.Invoke();
    }
    public void ResetRound()
    {
        ShowScheme();
        LastWordScreen.SetActive(false);
    }
}
