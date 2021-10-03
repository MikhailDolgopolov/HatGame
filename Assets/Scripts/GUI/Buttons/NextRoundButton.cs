using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    public void Action()
    {
        if (ReturnWordButton.wasUntouched) {
            Hat.myHat.PutWordBack();
        }
        GamePlay.ResetRound();
    }
}
