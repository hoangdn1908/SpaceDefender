using UnityEngine;

public class GamePlaySfx : MonoBehaviour
{
    [SerializeField] private AudioClip pauseSfx;
    [SerializeField] private AudioClip winSfx;
    [SerializeField] private AudioClip loseSfx;


    public void PlayWinSFX() 
    {
        if (winSfx == null) return;
        AudioManager.instance.PlaySfx(winSfx);
    }

    public void PlayPauseSFX() 
    {
        if (pauseSfx == null) return;
        AudioManager.instance.PlaySfx(pauseSfx);
    }

    public void PlayLoseSFX() 
    {
        if (loseSfx == null) return;
        AudioManager.instance.PlaySfx(loseSfx);
    }
}
