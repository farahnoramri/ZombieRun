
using UnityEngine;
public class Audio : MonoBehaviour
{
    public static Audio Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip mainMenuSound;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip collectBrainSound;
    [SerializeField] private AudioClip countdownSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        // Prevent duplicate Audio
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // MAIN MENU
    public void PlayMainMenu()
    {
        musicSource.clip = mainMenuSound;
        musicSource.loop = true;
        musicSource.Play();
    }

    // BUTTON CLICK
    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClickSound);
    }

    // COLLECT BRAIN
    public void PlayCollectBrain()
    {
        sfxSource.PlayOneShot(collectBrainSound);
    }

    // COUNTDOWN
    public void PlayCountdown()
    {
        sfxSource.PlayOneShot(countdownSound, 1f);
    }

    // GAME OVER
    public void PlayGameOver()
    {
        sfxSource.PlayOneShot(gameOverSound);
    }

    // JUMP
    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound,0.3f);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
