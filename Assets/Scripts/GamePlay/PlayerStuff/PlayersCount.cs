using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayersCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string s = "Игроки: ";
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update() {
        int n = PlayerCreator.playersCreated;
        if (n == 0) text.text = "Игроки";
        else
        text.text = s + n.ToString();
    }
}
