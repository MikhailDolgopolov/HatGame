using System.Collections;

public class RoundState : GameState {
    public RoundState(HatStateMachine machine) {
        stateMachine = machine;
    }

    public override void Start() {
        GUIManager.instance.onTimerEnded += Exit;
    }

    public override void MainButtonPressed() {
        //Hat.GetWord
        
    }

    public override void Exit() {
        GUIManager.instance.EndRound();
    }
}