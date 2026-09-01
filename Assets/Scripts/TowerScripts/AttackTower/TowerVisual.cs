using UnityEngine;

public class TowerVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetVisual(Sprite sprite) 
    {
        spriteRenderer.sprite = sprite;
    }
}
