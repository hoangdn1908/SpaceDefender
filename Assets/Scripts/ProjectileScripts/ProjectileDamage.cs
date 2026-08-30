using System;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public static Action OnProjectileHit;
    private int damage;

    public void SetDamage(int damage) 
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth == null) return;
            enemyHealth.TakeDamage(damage);
            OnProjectileHit?.Invoke();
        }
    }
}
