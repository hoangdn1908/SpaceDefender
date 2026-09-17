using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 1f;
        GameStateUI.instance.HideWinUI();
        GameStateUI.instance.HidePauseUI();
        GameStateUI.instance.HideLoseUI();
    }

    public void Exit()
    {
    }
}
