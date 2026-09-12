using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameModeData", menuName = "Scriptable Objects/GameModeData")]
public class GameModeData : ScriptableObject
{
    public List<WaveData> waves;
    public float delayBetweenWaves;
}

[Serializable]
public class WaveData 
{
    public List<SpawnGroup> spawnGroups;
}

[Serializable]
public class SpawnGroup 
{
    public EnemyData enemyData;
    public int count;
    public float delayBeforeGroup;
    public float delayBetweenSpawns;
}

