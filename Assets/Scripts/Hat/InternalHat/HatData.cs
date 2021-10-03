using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HatData
{
    public ArrayList words;
    public HatData(InternalHat hat)
    {
        words = new ArrayList();
        foreach (OldWord word in hat.Words) {
            words.Add(word.GetString());
        }
    }
    public HatData()
    {
        words = new ArrayList();
    }
}
