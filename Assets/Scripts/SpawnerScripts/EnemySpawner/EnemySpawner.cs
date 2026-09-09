using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool normalEnemyPool;
    [SerializeField] private ObjectPool bossPool;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private WaypointPath waypointPath;

    public EnemyController SpawnEnemy(EnemyData enemyData) 
    {
        ObjectPool pool = GetPool(enemyData.enemyType);
        GameObject enemyObj = pool.GetFromPool();
        enemyObj.transform.position = spawnPos.position;
        EnemyController enemy = enemyObj.GetComponent<EnemyController>();
        enemy.PrepareBeforeSpawn(enemyData, pool, waypointPath);
        return enemy;
    }

    private ObjectPool GetPool(EnemyType enemyType) 
    {
        switch (enemyType) 
        {
            case EnemyType.Boss:
                return bossPool;
            case EnemyType.Big:
            case EnemyType.Small:
            default:
                return normalEnemyPool;
        }
    }
}
