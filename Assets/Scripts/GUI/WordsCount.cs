using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsCount : MonoBehaviour
{
    private GameObject HatGameObject;
    private TextMeshProUGUI field;
    private int count;

    void Start()
    {
        HatGameObject = GameObject.Find("HatObject");
        field = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        count = Hat.Length;
        field.text = count.ToString();
    }
    
}
