using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundsInput : MonoBehaviour {
    public TMP_InputField input;
    public void SetRounds()
    {
        GameSettings.instance.numberOfBigRounds = Int32.Parse(input.text);
    }
}
