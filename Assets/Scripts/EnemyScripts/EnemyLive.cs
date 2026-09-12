using UnityEngine;

public class EnemyLive : MonoBehaviour
{
    private ObjectPool enemyPool;

    public void SetEnemyPool(ObjectPool objectPool) 
    {
        this.enemyPool = objectPool;
    }

    public void ReturnToPool() 
    {
        enemyPool.ReturnToPool(gameObject);
    }
}
