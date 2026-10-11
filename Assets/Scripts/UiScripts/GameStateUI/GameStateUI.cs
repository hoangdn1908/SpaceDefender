using UnityEngine;

public class GameStateUI : MonoBehaviour
{
    public static GameStateUI instance;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    private void Awake()
    {
        if (!TrySetSingleton()) return;
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

    public void ShowPauseUI() => pauseUI.SetActive(true);

    public void HidePauseUI() => pauseUI.SetActive(false);

    public void ShowWinUI() => winUI.SetActive(true);

    public void HideWinUI() => winUI.SetActive(false);

    public void ShowLoseUI() => loseUI.SetActive(true);

    public void HideLoseUI() => loseUI.SetActive(false);
}
