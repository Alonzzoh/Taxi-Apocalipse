using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerUI : MonoBehaviour {

    [SerializeField] private string mainMenuSceneName = "MainMenuScene";
    [SerializeField] private string gameplaySceneName = "Nivel1_whiteblocking";
    [SerializeField] private string gameOverSceneName = "Game Over";
    [SerializeField] private string victorySceneName = "Victory";
    [SerializeField] private string finalVictorySceneName = "FinalVictory";
    private static int lastSceneBuildIndex;
    private static string lastSceneName;

    private void SaveLastSceneName()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        lastSceneBuildIndex = currentScene.buildIndex;
        lastSceneName = currentScene.name;
    }

    public void GoToMainMenuScreen()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void GoToStartGame()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void GoToGameOverScreen()
    {
        SaveLastSceneName();
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void GoToVictoryScreen()
    {
        SaveLastSceneName();

        if (lastSceneBuildIndex == 3)
        {
            SceneManager.LoadScene(finalVictorySceneName);
        }
        else
        {
            SceneManager.LoadScene(victorySceneName);
        }
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(lastSceneBuildIndex + 1);
    }

    public void GoToRetryLevel()
    {
        SceneManager.LoadScene(lastSceneName);
    }

    public void GoToExitGame()
    {
        Application.Quit();
    }

}
