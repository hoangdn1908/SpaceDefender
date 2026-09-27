using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Resume()
    {
        GameManager.instance.ChangeToPlayingState();
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene() 
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScene = SceneManager.sceneCountInBuildSettings;
        if (nextSceneIndex < totalScene - 1)
            SceneManager.LoadScene(nextSceneIndex + 1);
        else
            Debug.Log("Het scene roi");
    }

    public void SetGameSpeed(float time) 
    {
        Time.timeScale = time;
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
