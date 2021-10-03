using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundPlayers : MonoBehaviour {
    public TextMeshProUGUI text;
    
    void Update() {
        Player[] p = GamePlay.currentPlayers;
        Console.WriteLine(p);
        text.text = p[0].name + " и " + p[1].name;
    }
}
