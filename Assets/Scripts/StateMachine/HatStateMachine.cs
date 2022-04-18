using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatStateMachine : StateMachine
{
    public void OnMainButtonPress() {
        currentState.MainButtonPressed();
    }

    public int UpdateCurrentPlayersScore(int inc) {
        return currentState.UpdateCurrentPlayersScore(inc);
    }
}
