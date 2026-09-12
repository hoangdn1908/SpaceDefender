using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement), typeof(EnemyDamage))]
[RequireComponent(typeof(EnemyLive), typeof(EnemyVisual))]
public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData {  get; private set; }
    private EnemyHealth enemyHealth;
    public EnemyMovement enemyMovement {  get; private set; }
    private EnemyVisual enemyVisual;
    public EnemyLive enemyLive {  get; private set; }
    private EnemyDamage enemyDamage;

    private void Awake()
    {
        InitializeComponent();
    }

    private void InitializeComponent() 
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyVisual = GetComponent<EnemyVisual>();
        enemyLive = GetComponent<EnemyLive>();
        enemyDamage = GetComponent<EnemyDamage>();
    }

    public void PrepareBeforeSpawn(EnemyData data, ObjectPool enemyPool, WaypointPath waypointPath) 
    {
        enemyData = data;
        enemyHealth.SetHealth(enemyData.maxHealth);
        enemyMovement.ResetCurrentWayPointIndex();
        enemyMovement.SetSpeed(enemyData.speed);
        enemyMovement.SetRotationSpeed(enemyData.rotationSpeed);
        enemyMovement.SetPath(waypointPath);
        enemyVisual.SetColliderRadius(enemyData.colliderRadius);
        enemyVisual.SetSprite(enemyData.sprites);
        enemyLive.SetEnemyPool(enemyPool);
        enemyDamage.SetDamage(enemyData.damage);
    }
}
