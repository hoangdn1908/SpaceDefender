using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;

    private void OnEnable()
    {
        GameEvents.OnEnemyReachGoal += TakeDamage;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyReachGoal -= TakeDamage;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        GameEvents.RaisePlayerHealthChanged(currentHealth);
        if (!IsAlive())
        {
            GameEvents.RaiseGameLose();
        }
    }

    private bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void SetCurrentHealth(int maxHealth)
    {
        currentHealth = maxHealth;
        GameEvents.RaisePlayerHealthChanged(currentHealth);
    }
}
