using UnityEngine;

public class WinState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;
        GameStateUI.instance.HidePauseUI();
        GameStateUI.instance.HideLoseUI();
        GameStateUI.instance.ShowWinUI();
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        GameStateUI.instance.HideWinUI();
    }
}
