using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    private List<EnemyController> activeEnemies = new List<EnemyController>();

    private void Awake()
    {
        if (!TrySetSingleton()) return;
    }

    private void OnEnable()
    {
        GameEvents.OnEnemySpawned += HandleRegisterEnemy;
        GameEvents.OnEnemyFinished += HandleRemoveEnemy;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemySpawned -= HandleRegisterEnemy; 
        GameEvents.OnEnemyFinished -= HandleRemoveEnemy;
    }

    private bool TrySetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return false;
        }
        instance = this;
        return true;
    }

    private void HandleRegisterEnemy(EnemyController enemyController) 
    {
        activeEnemies.Add(enemyController);
    }

    private void HandleRemoveEnemy(EnemyController enemy) 
    {
        activeEnemies.Remove(enemy);
    }

    public bool HasEnemies() 
    {
        return activeEnemies.Count > 0;
    }
}
