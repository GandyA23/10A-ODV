public class PlayerFreeLookState : PlayerBaseState
{
    private PlayerStateMachine playerStateMachine;

    public PlayerFreeLookState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }
}