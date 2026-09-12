using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        SetCurrentHealth();    
    }

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

    private void SetCurrentHealth() 
    {
        currentHealth = maxHealth;
        GameEvents.RaisePlayerHealthChanged(currentHealth);
    }

}
