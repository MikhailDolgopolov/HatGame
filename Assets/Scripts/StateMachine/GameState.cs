using System;
using System.Collections;

public abstract class GameState {
    protected HatStateMachine stateMachine;
    public virtual void Start() {
    }

    public virtual IEnumerator Update() {
        yield return null;
    }

    public virtual void MainButtonPressed() {
        
    }

    public virtual int UpdateCurrentPlayersScore(int inc) {
        throw new NotImplementedException();
    }

    public virtual void Exit() {
    }
}