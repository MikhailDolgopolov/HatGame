using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TextureSetter : MonoBehaviour
{
    public ImageCollection textures;
    void Start()
    {
        GetComponent<Image>().sprite = textures.GetRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
