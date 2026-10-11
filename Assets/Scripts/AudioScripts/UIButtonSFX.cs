using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSFX : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioClip hoverSFX;
    [SerializeField] private AudioClip clickSFX;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSFX == null) return;
        AudioManager.instance.PlaySfx(hoverSFX);
    }

    public void OnClick()
    {
        if (clickSFX == null) return;
        AudioManager.instance.PlaySfx(clickSFX);
    }
}