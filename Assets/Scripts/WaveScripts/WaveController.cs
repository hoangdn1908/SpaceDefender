using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private GameModeData gameModeData;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private float delayBetweenWaves;
    private int currentWaveIndex;

    private void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves() 
    {
        while (currentWaveIndex < gameModeData.waves.Count) 
        {
            yield return StartCoroutine(SpawnWave(gameModeData.waves[currentWaveIndex]));
            currentWaveIndex++;
            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(WaveData wave) 
    {
        foreach (SpawnGroup group in wave.spawnGroups) 
        {
            yield return new WaitForSeconds(group.delayBeforeGroup);
            for (int i = 0; i < group.count; i++) 
            {
                enemySpawner.SpawnEnemy(group.enemyData);
                yield return new WaitForSeconds(group.delayBetweenSpawns);
            }
        }
    }
}
