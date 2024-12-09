using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentIndex;
    public LevelUI lvlUI;
    int mainMenu_Index = 0;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnLevelComplete()
    {
        Debug.Log("Level Complete");
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        int nextLevel = currentIndex + 1;
        int TotalLevels = SceneManager.sceneCountInBuildSettings;

        if (nextLevel < TotalLevels)
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            lvlUI.ShowGameWinUI();
        }
    }

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenu_Index);

    public void OnPlayerDead() => lvlUI.ShowLevelLoseUI();

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentIndex);
    }
}
