using UnityEngine;
using UnityEngine.Rendering;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D circleCollider;

    public void SetSprite(Sprite[] sprites) 
    {
        if (sprites.Length == 0) return;
        int index = Random.Range(0, sprites.Length);
        this.spriteRenderer.sprite = sprites[index];
    }

    public void SetColliderRadius(float radius) 
    {
        this.circleCollider.radius = radius;
    }
}
