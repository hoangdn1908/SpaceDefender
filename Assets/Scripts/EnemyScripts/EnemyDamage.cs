using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damage) 
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController == null) return;
            playerController.TakeDamage(damage);
        }
    }
}
