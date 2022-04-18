using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {
    public static SettingsManager instance;
    public GameSettings settings;
    void Start() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GeneratePairs()
    {
        int n = settings.numberOfPlayers;
        settings.pairs = new int[n * (n - 1)*settings.numberOfBigRounds, 2];
        int id = 0;
        for (int j = 0; j < settings.numberOfBigRounds; j++) {
            id = PairsCycle(id);
        }
    }
    int PairsCycle(int id) {
        for(int inc = 1; inc < settings.numberOfPlayers; inc++)
        {
            foreach (int p in settings.players.Keys)
            {
                
                settings.pairs[id, 0] = p;
                settings.pairs[id, 1] = (p + inc) % settings.numberOfPlayers;
                id++;
            }
            
        }

        return id;
    }
    public void SortPlayers()
    {
        settings.sortedPlayers = new Player[settings.numberOfPlayers];
        settings.players.Values.CopyTo(settings.sortedPlayers, 0);
        Array.Sort(settings.sortedPlayers, new PlayerComparer());
    }
    
    public void RemovePlayer(int index) {
        if (settings.players.ContainsKey(index)) {
            settings.players.Remove(index);
        }
    }
    public void AddPlayer(int index, string name)
    {
        if (index >= settings.players.Count)
        {
            settings.players.Add(index, new Player(name));
        }
        else
        {
            settings.players[index].name = name;
        }
        
    }

    public Player[] NextPlayers(int round) {
        return new Player[]
        {
            settings.players[settings.pairs[round - 1, 0]],
            settings.players[settings.pairs[round - 1, 1]]
        };
    }
}
