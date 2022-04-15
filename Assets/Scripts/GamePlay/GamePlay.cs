using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public static int currentRound;
    public enum state { beginning, round, stop }
    public static state currentState = state.beginning;
    
    [HideInInspector]
    public static Player[] currentPlayers;
    public static int currentPlayersScore;
    private static int startingScore;

    public delegate void gameEvent();
    public static event gameEvent OnNewRound;
    public static event gameEvent OnRoundStart;
    public static event gameEvent OnRoundEnded;
    public static event gameEvent OnGameEnded;
    
    void Start()
    {
        //Hat.GameBegan();
        currentRound = 1;
        NextPlayers();
    }
    static void NextPlayers() {
        currentPlayers = new Player[2]
        {
            GameSettings.players[GameSettings.pairs[currentRound-1, 0]], 
            GameSettings.players[GameSettings.pairs[currentRound-1, 1]]
        };
        currentPlayersScore = 0;
        OnNewRound?.Invoke();
    }
    
    public static void UpdateCurrentPlayersScore(int inc) {
        if (currentState == state.stop && currentPlayersScore >= startingScore && inc > 0) return;
        currentPlayersScore += inc;
        if (currentState == state.round) startingScore = currentPlayersScore;
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
        currentState = state.round;
        OnRoundStart?.Invoke();
    }
    public static void EndRound() 
    {
        currentState = state.stop;
        OnRoundEnded?.Invoke();
    }
    static void SetScore()
    {
        foreach(Player p in currentPlayers)
        {
            p.points += currentPlayersScore;
            
        }
    }
    public static void RoundsEnded() {
        OnGameEnded?.Invoke();
        GameSettings.SortPlayers();
        SceneManager.LoadScene("Results");
    }
    public static void ResetRound()
    {
        SetScore();
        currentRound += 1;
        if (currentRound-1 == GameSettings.pairs.GetLength(0)) {
            RoundsEnded();
            return;
        }
        currentState = state.beginning;
        NextPlayers();
    }
}
