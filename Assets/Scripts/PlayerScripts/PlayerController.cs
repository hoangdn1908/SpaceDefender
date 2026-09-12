using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;    
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log(currentHealth);
        if (!IsAlive()) 
        {
            gameObject.SetActive(false);
        }
    }

    private bool IsAlive() 
    {
        return currentHealth > 0;
    }
}
