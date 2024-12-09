using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{

    public TextMeshProUGUI level_Text, gameOver_Text;
    private int level_Number;

    public GameObject gameOverPanel, levelPanel;
    public Button restart_Button, mainMenu_Button;

    public LevelManager levelManager;
    private SoundManager soundManager;


    private void Awake()
    {
        AddListener();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        level_Number = SceneManager.GetActiveScene().buildIndex;
        UpdateLevelText();
    }


    void UpdateLevelText()
    {
        level_Text.text = "LEVEL : " + level_Number;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    public void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

    void AddListener()
    {
        restart_Button.onClick.AddListener(RestartButton);
        mainMenu_Button.onClick.AddListener(MainMenuButton);
    }

    public void MainMenuButton()
    {
        soundManager.PlayButtonAudio();
        soundManager.DestroySoundManager();
        levelManager.LoadMainMenu();
    }
    public void RestartButton()
    {
        //Debug.Log("Restart");
        soundManager.PlayButtonAudio();

        levelManager.RestartLevel();
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);
        gameOver_Text.text = "GAME COMPLETED!!";
        gameOver_Text.color = Color.green;

        HideLevelPanel();

    }

    public void ShowLevelLoseUI()
    {
        SetGameOverPanel(true);

        gameOver_Text.text = "GAME OVER!!";
        gameOver_Text.color = Color.red;
        HideLevelPanel();
    }
}
