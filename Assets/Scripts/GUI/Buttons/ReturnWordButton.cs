using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReturnWordButton : MonoBehaviour {
    public TwoStateButton myButton;
    public static TextMeshProUGUI myText;
    public static bool wasPressed;
    public static bool firstPress = true, wasUntouched=true;

    private static string s = " последнее слово";

    void Awake() {
        GUIManager.onTimerEnded += Reset;
        myText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        myButton = GetComponent<TwoStateButton>();
    }
    public void Reset() {
        myButton.isPressed = false;
        wasPressed = false;
        myText.text = "Добавить" + s;
        firstPress = wasUntouched = true;
    }
    public void AddScore() {
        wasPressed = true;
        myText.text = "Убрать" + s;
        //Hat.myHat.RemoveLastWord(firstPress);
        GamePlay.UpdateCurrentPlayersScore(1, firstPress);
        firstPress = wasUntouched = false;
    }

    public void SubtractScore() {
        firstPress = wasPressed = wasUntouched = false;
        GamePlay.UpdateCurrentPlayersScore(-1);
        //Hat.myHat.PutWordBack();
        myText.text = "Добавить" + s;
    }
}
