
public class GameStateMachine
{
    protected IGameState currentState;

    public void ChangeState(IGameState gameState) 
    {
        currentState?.Exit();
        currentState = gameState;
        currentState.Enter();
    }
}
