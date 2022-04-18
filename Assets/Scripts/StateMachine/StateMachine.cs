using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour {
    protected GameState currentState { get; private set; }

    public void SetState(GameState state) {
        currentState.Exit();
        currentState = state;
        currentState.Start();
    }
}