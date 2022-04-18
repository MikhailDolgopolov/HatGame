using JetBrains.Annotations;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class GameSettings : MonoBehaviour {
    public static GameSettings instance;
    public Dictionary<int, Player> players;
    public Player[] sortedPlayers;
    public int numberOfBigRounds;
    public int secondsPerRound=30;
    public int numberOfPlayers
    {
        get { return players.Count; }
        set { return; }
    }
    public int numberOfRounds
    {
        get { return players.Count * (players.Count - 1); }
    }
    public int[,] pairs;
    
    void Start() {
        instance = this;
        numberOfBigRounds = 1;
        players = new Dictionary<int, Player>();
    }
    
    
    
    void PrintPlayers()
    {
        string allWords = "";
        
        foreach (Player w in players.Values)
        {
            allWords += w.name;
            allWords += ", ";
        }
        Debug.Log(allWords);
    }
    void PrintScores()
    {
        string s = "";
        foreach(Player p in players.Values)
        {
            s += p.ToString() + "; ";
        }
        Debug.Log(s);
    }
    void PrintPairs()
    {
        string p = "";
        for (int i = 0; i < pairs.GetLength(0); i++)
        {
            p += "(";
            for (int j = 0; j < pairs.GetLength(1); j++)
            {
                p += players[pairs[i, j]].name.ToString();
                p += " ";
            }
            p += "), ";
        }
        Debug.Log(p);
    }
}
