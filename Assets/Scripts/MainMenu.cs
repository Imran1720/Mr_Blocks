using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public const int firstLevel = 1;
    public Button playButton, quitButton;
    private SoundManager soundManager;

    private void Awake()
    {
        AddListener();
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void Play()
    {
        soundManager.PlayButtonAudio();
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        soundManager.PlayButtonAudio();
        Application.Quit();
    }

    void AddListener()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }
}
