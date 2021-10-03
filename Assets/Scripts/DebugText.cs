using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour {
    public static DebugText d;
    public TextMeshProUGUI field;
    // Start is called before the first frame update
    void Awake() {
        //field = GetComponent<TextMeshProUGUI>();
        d = this;
    }

    // Update is called once per frame
    public static void Log(object message, bool nLine=true) {
        if (nLine)d.field.text += System.Environment.NewLine;
        d.field.text += message.ToString()+" ";
        
    }
}
