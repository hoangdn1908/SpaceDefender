using UnityEngine;

public class RandomVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        ChangeRamdomVisual();
    }

    private void ChangeRamdomVisual() 
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
