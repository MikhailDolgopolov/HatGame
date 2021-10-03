using JetBrains.Annotations;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class GameSettings : MonoBehaviour
{
    public static Dictionary<int, Player> players;

    public static Player[] sortedPlayers;
    public static int numberOfBigRounds;
    public static int secondsPerRound=30;
    public static int numberOfPlayers
    {
        get { return players.Count; }
        set { return; }
    }
    public static int[,] pairs;
    public static GameObject GObject { get; private set; }
    void Start() {
        numberOfBigRounds = 1;
        players = new Dictionary<int, Player>();
        DontDestroyOnLoad(gameObject);
        GObject = gameObject;
    }

    public static void RemovePlayer(int index) {
        if (players.ContainsKey(index)) {
            players.Remove(index);
        }
    }
    public static void AddPlayer(int index, string name)
    {
        if (index >= players.Count)
        {
            players.Add(index, new Player(name));
        }
        else
        {
            players[index].name = name;
        }
        
    }
    static void PrintPlayers()
    {
        string allWords = "";
        
        foreach (Player w in players.Values)
        {
            allWords += w.name;
            allWords += ", ";
        }
        Debug.Log(allWords);
    }
    public static void GeneratePairs()
    {
        int n = numberOfPlayers;
        pairs = new int[n * (n - 1)*numberOfBigRounds, 2];
        int id = 0;
        for (int j = 0; j < numberOfBigRounds; j++) {
            id = PairsCycle(id);
        }
    }

    static int PairsCycle(int id) {
        for(int inc = 1; inc < numberOfPlayers; inc++)
        {
            foreach (int p in players.Keys)
            {
                
                pairs[id, 0] = p;
                pairs[id, 1] = (p + inc) % numberOfPlayers;
                id++;
            }
            
        }

        return id;
    }
    public static void SortPlayers()
    {
        sortedPlayers = new Player[numberOfPlayers];
        players.Values.CopyTo(sortedPlayers, 0);
        Array.Sort(sortedPlayers, new PlayerComparer());
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
