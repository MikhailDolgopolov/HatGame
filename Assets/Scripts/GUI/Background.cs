using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public static GameObject I;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(I == null)
        {
            I = gameObject;
            return;
        }
        if (GameObject.Find("Background") != gameObject)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    
}
