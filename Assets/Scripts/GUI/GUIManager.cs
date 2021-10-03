using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public GameObject Timer;
    public GameObject Scheme;
    public GameObject LastWordScreen;

    public delegate void GUIEvent();

    public static event GUIEvent onTimerEnded;
    
    
    void Start()
    {
        LastWordScreen.SetActive(false);
        GamePlay.OnRoundStart += ShowTimer;
        GamePlay.OnNewRound += ShowScheme;
        GamePlay.OnRoundEnded += End;
    }
    void ShowTimer()
    {
        Scheme.SetActive(false);
        Timer.SetActive(true);
    }
    void ShowScheme()
    {
        Scheme.SetActive(true);
        Timer.SetActive(false);
        LastWordScreen.SetActive(false);
    }

    
    public void End()
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
