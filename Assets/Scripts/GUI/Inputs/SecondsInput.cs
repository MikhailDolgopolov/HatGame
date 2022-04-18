using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SecondsInput : MonoBehaviour
{
    private TMP_InputField field;
    // Start is called before the first frame update
    void Start()
    {
        field = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    public void UpdateSeconds()
    {
        string n = field.text;
        if (n == "") {
            GameSettings.instance.secondsPerRound = 30;
            return;
        }
        GameSettings.instance.secondsPerRound = Int32.Parse(n);
        
    }
}
