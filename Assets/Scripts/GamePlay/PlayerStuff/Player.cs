using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public int points = 0;
    public Player(string _name)
    {
        name = _name;
    }
    public override string ToString()
    {
        return name + ": " + points.ToString();
    }
}
