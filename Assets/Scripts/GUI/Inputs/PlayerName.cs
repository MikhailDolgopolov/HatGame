using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour {
    public TMP_InputField field;
    public int index;
    // Start is called before the first frame update
    void Start() {
        index = transform.GetSiblingIndex();
    }

    
    public void Change() {
        if (field == null) field = GetComponent<TMP_InputField>();
        GameSettings.AddPlayer(index, field.text);
    }
}
