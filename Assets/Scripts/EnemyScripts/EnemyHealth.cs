using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        if (!IsAlive())
        {
            gameObject.SetActive(false);
            return;
        }
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    private bool IsAlive() 
    {
        return currentHealth > 0;
    }
}
