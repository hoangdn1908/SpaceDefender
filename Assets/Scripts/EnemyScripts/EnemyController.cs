using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement), typeof(EnemyVisual))] 
public class EnemyController : MonoBehaviour
{
    public EnemyData EnemyData;
    private EnemyHealth enemyHealth;
    private EnemyMovement enemyMovement;
    private EnemyVisual enemyVisual;

    private void Awake()
    {
        InitializeComponent();
        SetValues();
    }

    private void InitializeComponent() 
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyVisual = GetComponent<EnemyVisual>();
    }

    public void SetValues() 
    {
        enemyHealth.SetHealth(EnemyData.maxHealth);
        enemyMovement.SetSpeed(EnemyData.speed);
        enemyMovement.SetRotationSpeed(EnemyData.rotationSpeed);
        enemyVisual.SetColliderRadius(EnemyData.colliderRadius);
        enemyVisual.SetSprite(EnemyData.sprites);
    }
}
