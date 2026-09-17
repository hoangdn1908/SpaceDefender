using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        GameEvents.RaisePlayerHealthChanged(currentHealth);
        if (!IsAlive())
        {
            gameObject.SetActive(false);
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
