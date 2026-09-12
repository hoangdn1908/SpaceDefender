using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private GameModeData gameModeData;
    [SerializeField] private EnemySpawner enemySpawner;
    private int currentWaveIndex;

    private void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves() 
    {
        while (currentWaveIndex < gameModeData.waves.Count) 
        {
            GameEvents.RaiseWaveChanged(currentWaveIndex, gameModeData.waves.Count);
            yield return new WaitForSeconds(gameModeData.delayBetweenWaves);
            yield return StartCoroutine(SpawnWave(gameModeData.waves[currentWaveIndex]));
            yield return new WaitUntil(() => !EnemyManager.instance.HasEnemies());
            currentWaveIndex++;
        }
    }

    private IEnumerator SpawnWave(WaveData wave) 
    {
        foreach (SpawnGroup group in wave.spawnGroups) 
        {
            yield return new WaitForSeconds(group.delayBeforeGroup);
            yield return StartCoroutine(SpawnGroup(group));
        }
    }

    private IEnumerator SpawnGroup(SpawnGroup group) 
    {
        for (int i = 0; i < group.count; i++)
        {
            EnemyController enemy = enemySpawner.SpawnEnemy(group.enemyData);
            GameEvents.RaiseEnemySpawned(enemy);
            yield return new WaitForSeconds(group.delayBetweenSpawns);
        }
    }
}
