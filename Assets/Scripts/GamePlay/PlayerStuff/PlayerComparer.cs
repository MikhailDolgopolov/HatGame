using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComparer : IComparer<Player>
{
    int IComparer<Player>.Compare(Player x, Player y)
    {
        if (x.points < y.points) return 1;
        if (x.points == y.points) return 0;
        return -1;
    }
}
