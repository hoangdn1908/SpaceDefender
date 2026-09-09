using System.ComponentModel;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    private int currentHealth;

    public void SetHealth(int health) 
    {
        this.currentHealth = health;
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (!IsAlive())
        {
            GameEvents.OnEnemyFinished(this.enemyController);
            enemyController.enemyLive.ReturnToPool();
        }
    }

    private bool IsAlive() 
    {
        return currentHealth > 0;
    }
}
