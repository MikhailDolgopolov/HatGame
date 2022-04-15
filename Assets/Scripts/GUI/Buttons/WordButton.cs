using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class WordButton : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string str = "Начать";
    // Start is called before the first frame update
    void Awake()
    {
        text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        GamePlay.OnNewRound += Reset;
    }
    
    public void ButtonAction()
    {
        /*if (GamePlay.currentState == GamePlay.state.beginning)
        {
            if (Hat.Length < Hat.wordsThreshold)
            {
                ToastMessages.ShowMessage("В шляпе недостаточно слов.");
                GamePlay.RoundsEnded();
                return;
            }
            GrabWord();
            GamePlay.StartRound();
            return;
        }
        if (GamePlay.currentState == GamePlay.state.round)
        {
            
            if (Hat.Length > 0)
            {
                Hat.myHat.WordButtonPressed();
                GamePlay.UpdateCurrentPlayersScore(1);
                GrabWord();
            }
        }*/
    }
    public void Reset()
    {
        text.text = str;
    }
    void GrabWord() {
        throw new NotImplementedException();
    }
}
