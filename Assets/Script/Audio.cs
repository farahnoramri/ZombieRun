using UnityEngine;

public class Audio: MonoBehaviour
{
public static Audio Instance;

[Header("Audio Sources")]
[SerializeField] private AudioSource musicSource;
[SerializeField] private AudioSource sfxSource;
[SerializeField] private AudioSource runningSource;

[Header("Audio Clips")]
[SerializeField] private AudioClip mainMenuSound;
[SerializeField] private AudioClip buttonClickSound;
[SerializeField] private AudioClip collectBrainSound;
[SerializeField] private AudioClip countdownSound;
[SerializeField] private AudioClip gameOverSound;
[SerializeField] private AudioClip jumpSound;
[SerializeField] private AudioClip runningSound;

private void Awake()
{
// Prevent duplicate AudioManagers
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
runningSource.Stop();

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
musicSource.Stop();
runningSource.Stop();

sfxSource.PlayOneShot(countdownSound);
}

// GAME OVER
public void PlayGameOver()
{
runningSource.Stop();
sfxSource.PlayOneShot(gameOverSound);
}

// JUMP
public void PlayJump()
{
sfxSource.PlayOneShot(jumpSound);
}

// RUNNING
public void PlayRunning()
{
if (!runningSource.isPlaying)
{
runningSource.clip = runningSound;
runningSource.loop = true;
runningSource.Play();
}
}

public void StopRunning()
{
runningSource.Stop();
}

private void Awake()
{
    // Prevent duplicate AudioManagers
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);

    // Automatically create Audio Sources if they aren't assigned in the Inspector
    SetupAudioSources();
}

private void SetupAudioSources()
{
    // Check and add Music Source
    if (musicSource == null)
    {
        musicSource = gameObject.AddComponent<AudioSource>();
    }

    // Check and add SFX Source
    if (sfxSource == null)
    {
        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    // Check and add Running Source
    if (runningSource == null)
    {
        runningSource = gameObject.AddComponent<AudioSource>();
    }
}

}