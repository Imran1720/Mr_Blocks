using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioSource soundFXAudioSource;

    public AudioClip levelCompleteAudio;
    public AudioClip gameOverAudio;
    public AudioClip buttonClickAudio;


    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null || !backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
    }

    public void PlayLevelCompleteAudio()
    {
        if (soundFXAudioSource != null && levelCompleteAudio != null)
        {
            soundFXAudioSource.PlayOneShot(levelCompleteAudio);
        }
    }

    public void PlayGameOverAudio()
    {
        if (soundFXAudioSource != null && gameOverAudio != null)
        {
            soundFXAudioSource.PlayOneShot(gameOverAudio);
        }
    }

    public void PlayButtonAudio()
    {
        if (soundFXAudioSource != null && buttonClickAudio != null)
        {
            soundFXAudioSource.PlayOneShot(buttonClickAudio);
        }
    }

    public void DestroySoundManager()
    {
        Destroy(gameObject);
    }
}
