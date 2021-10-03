using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsNumber : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update() {
        text.text = GamePlay.currentPlayersScore.ToString();
    }
}
