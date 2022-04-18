using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public static int currentRound;
   
    
    [HideInInspector]
    public static Player[] currentPlayers;
    public static int currentPlayersScore;
    private static int startingScore;
    

    void Start()
    {
        currentRound = 1;
        NextPlayers();
    }
    static void NextPlayers() {
        currentPlayers = SettingsManager.instance.NextPlayers(currentRound);
        currentPlayersScore = 0;
    }
    
    public static void UpdateCurrentPlayersScore(int inc) {
        if (currentPlayersScore >= startingScore && inc > 0) return;
        currentPlayersScore += inc;
        startingScore = currentPlayersScore;
    }

    public static void UpdateCurrentPlayersScore(int inc, bool ImSpecial) {
        if (ImSpecial) {
            currentPlayersScore += inc;
            startingScore = currentPlayersScore;
            return;
        }
        UpdateCurrentPlayersScore(inc);
    }
    
    
    public static void StartRound() {
        throw new NotImplementedException();
        //currentState = state.round;
    }
    public static void EndRound() 
    {
        throw new NotImplementedException();
        //currentState = state.stop;
    }
    static void SetScore()
    {
        foreach(Player p in currentPlayers)
        {
            p.points += currentPlayersScore;
            
        }
    }
    public static void RoundsEnded() {
        SettingsManager.instance.SortPlayers();
        SceneManager.LoadScene("Results");
    }
    public static void ResetRound()
    {
        SetScore();
        currentRound += 1;
        if (currentRound-1 == GameSettings.instance.numberOfRounds) {
            RoundsEnded();
            return;
        }
        //currentState = state.beginning;
        throw new NotImplementedException();
        NextPlayers();
    }
}
