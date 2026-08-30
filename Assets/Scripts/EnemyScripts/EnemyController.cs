using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement))] 
public class EnemyController : MonoBehaviour
{
    public EnemyData EnemyData;
    private EnemyHealth enemyHealth;
    private EnemyMovement enemyMovement;

    private void Awake()
    {
        InitializeComponent();
        SetValues();
    }

    private void InitializeComponent() 
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void SetValues() 
    {
        enemyHealth.SetHealth(EnemyData.maxHealth);
        enemyMovement.SetSpeed(EnemyData.speed);
        enemyMovement.SetRotationSpeed(EnemyData.rotationSpeed);
    }
}
