using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PaperTexture", menuName = "Sprites/Image Collection")]
public class ImageCollection : ScriptableObject
{
    public Sprite[] textures;
    // Start is called before the first frame update
    public Sprite GetRandom()
    {
        return textures[Random.Range(0, textures.Length)];
    }

}
