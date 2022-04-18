using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class AddWordButton : MonoBehaviour
{
    public GameObject inputField;
    private TMP_InputField field;
    void Start()
    {
        field = inputField.GetComponent<TMP_InputField>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddWord();
        }
    }
    
    public void AddWord()
    {
        string word = field.text;
        string trim = Regex.Replace(word, @"s", "");
        if (trim == "")
            return;
        
        ToastMessages.ShowMessage("Такое слово уже есть в шляпе.");
    }
}
