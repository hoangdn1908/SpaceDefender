using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSFX : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioClip hoverSFX;
    [SerializeField] private AudioClip clickSFX;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlaySfx(hoverSFX);
    }

    public void OnClick()
    {
        AudioManager.instance.PlaySfx(clickSFX);
    }
}