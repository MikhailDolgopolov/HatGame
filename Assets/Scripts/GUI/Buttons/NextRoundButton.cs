using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    public void Action()
    {
        if (ReturnWordButton.wasUntouched) {
            throw new NotImplementedException();
        }
        GamePlay.ResetRound();
    }
}
