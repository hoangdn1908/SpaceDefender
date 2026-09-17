using UnityEngine;

public class LoseState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;
        GameStateUI.instance.HidePauseUI();
        GameStateUI.instance.HideWinUI();
        GameStateUI.instance.ShowLoseUI();
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        GameStateUI.instance.HideLoseUI();
    }
}
