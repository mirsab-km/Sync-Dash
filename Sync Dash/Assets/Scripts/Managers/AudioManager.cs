using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource sfxSource;

    public AudioClip jumpSoundClip;
    public AudioClip collectSoundClip;
    public AudioClip gameOverClip;

    private void OnEnable()
    {
        GameEvents.onPlayerDied += GameOverSound;
    }

    private void OnDisable()
    {
        GameEvents.onPlayerDied -= GameOverSound;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void JumpSound()
    {
        sfxSource.PlayOneShot(jumpSoundClip);
    }

    public void CollectSound()
    {
        sfxSource.PlayOneShot(collectSoundClip);
    }

    public void GameOverSound()
    {
        sfxSource.PlayOneShot(gameOverClip);
    }
}
