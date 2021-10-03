using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Hat : MonoBehaviour {
    public static IHat myHat;
    public static int wordsThreshold=5;
    public static bool useOnlineHat;
    public delegate void Event();
    public static event Event HatChanged;
    
    public static int Length
    {
        get
        {
            if (myHat == null) return 0;
            return myHat.GetLength();
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
        useOnlineHat = false;
    }

    void Start() {
        SetupHat();
    }
    public static void SetupHat() {
        HatChanged?.Invoke();
        if (useOnlineHat) {
            WordsTable.Setup();
            InternalHat.Save();
            myHat = new OnlineHat();
            return;
        }
        myHat = new InternalHat();
    }

    static void PrepareForRound() {
        myHat.PrepareForRound();
    }
    static void RoundEnded() {
        myHat.RoundEnded();
    }

    static void GameEnded() {
        myHat.GameEnded();
    }

    public static void GameBegan() {
        GamePlay.OnNewRound += PrepareForRound;
        GamePlay.OnRoundEnded += RoundEnded;
        GamePlay.OnGameEnded += GameEnded;
    }
}
