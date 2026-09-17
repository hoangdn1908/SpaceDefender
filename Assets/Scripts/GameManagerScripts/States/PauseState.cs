using UnityEngine;

public class PauseState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;

        GameStateUI.instance.HideWinUI();
        GameStateUI.instance.HideLoseUI();
        GameStateUI.instance.ShowPauseUI();
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        GameStateUI.instance.HidePauseUI();
    }
}
