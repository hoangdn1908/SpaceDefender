using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameStateMachine gameStateMachine;
    private PlayingState playingState;
    private PauseState pauseState;
    private WinState winState;
    private LoseState loseState;

    private void Awake()
    {
        instance = this;
        InitializeGameState();
    }

    private void OnEnable()
    {
        GameEvents.OnGameWin += ChangeToWinState;
        GameEvents.OnGameLose += ChangeToLoseState;
    }

    private void OnDisable()
    {
        GameEvents.OnGameWin -= ChangeToWinState;
        GameEvents.OnGameLose -= ChangeToLoseState;
    }

    private void Start()
    {
        ChangeToPlayingState();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ChangeToPauseState();
        }
    }

    private void InitializeGameState() 
    {
        gameStateMachine = new GameStateMachine();
        playingState = new PlayingState();
        pauseState = new PauseState();
        winState = new WinState();
        loseState = new LoseState();
    }

    #region Change state
    public void ChangeToPlayingState() 
    {
        gameStateMachine.ChangeState(playingState);
    }

    private void ChangeToPauseState() 
    {
        gameStateMachine.ChangeState(pauseState);
    }

    private void ChangeToWinState() 
    {
        gameStateMachine.ChangeState(winState);
    }

    private void ChangeToLoseState() 
    {
        gameStateMachine.ChangeState(loseState);
    }

    #endregion
}
