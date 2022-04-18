using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Web.Data;
using UnityEngine;

public class WebData : MonoBehaviour {
    public static WebData instance;
    private WordStorage ws;
    public WordStorage mainStorage
    {
        get
        {
            return ws;
        }
        set
        {
            freshWords = value.Words;
            ws = value;
        }
    }

    public List<WebWord> freshWords;
    // Start is called before the first frame update
    void Start() {
        instance = this;
        freshWords = new List<WebWord>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
