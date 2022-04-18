using System.Collections;

public class WaitForRoundState : GameState {
    public WaitForRoundState(HatStateMachine machine) {
        stateMachine = machine;
    }
    public override void Start() {
        //UI Action
    }

    public override void MainButtonPressed() {
        
        stateMachine.SetState(new RoundState(stateMachine));
    }
}
