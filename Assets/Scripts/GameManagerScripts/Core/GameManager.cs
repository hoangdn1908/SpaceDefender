using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GamePlaySfx gamePlaySfx;
    private GameStateMachine gameStateMachine;
    private PlayingState playingState;
    private PauseState pauseState;
    private WinState winState;
    private LoseState loseState;
    private bool isPlaying;

    private void Awake()
    {
        if (!TrySetSingleton()) return;
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
        if (Input.GetKeyDown(KeyCode.Escape) && isPlaying)
        {
            ChangeToPauseState();
        }
    }

    private bool TrySetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return false;
        }
        instance = this;
        return true;
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
        isPlaying = true;
    }

    private void ChangeToPauseState() 
    {
        gameStateMachine.ChangeState(pauseState);
        gamePlaySfx.PlayPauseSFX();
        isPlaying = false;
    }

    private void ChangeToWinState() 
    {
        gameStateMachine.ChangeState(winState);
        gamePlaySfx.PlayWinSFX();
        isPlaying = false;
    }

    private void ChangeToLoseState() 
    {
        gameStateMachine.ChangeState(loseState);
        gamePlaySfx.PlayLoseSFX();
        isPlaying = false;
    }

    #endregion
}
