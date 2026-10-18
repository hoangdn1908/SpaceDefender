using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (!TrySetSingleton()) return;
    }

    private bool TrySetSingleton() 
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
            return false;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        return true;
    }

    public void PlaySfx(AudioClip audioClip) 
    {
        if (audioClip == null) return;
        sfxSource.PlayOneShot(audioClip);
    }

}
