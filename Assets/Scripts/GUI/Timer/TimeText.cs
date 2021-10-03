using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TimerCircle t;
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(Mathf.CeilToInt(t.timer.time));
        string str = time.ToString(@"mm\:ss");
        text.text = str;
    }
}
