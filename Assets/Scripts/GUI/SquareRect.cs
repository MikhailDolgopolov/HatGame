using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class SquareRect : MonoBehaviour {
    private RectTransform t;

    private float height;
    // Start is called before the first frame update
    void Start() {
        t = GetComponent<RectTransform>();
        height = t.sizeDelta.y;
        Set();
    }

    void Set() {
        t.sizeDelta=new Vector2(height,height);
    }

    void OnRenderObject() {
        Set();
    }
    // Update is called once per frame
    void Update()
    {
        if(t is null) Start();
        if(t.sizeDelta.x!=height) Set();   
    }
}
