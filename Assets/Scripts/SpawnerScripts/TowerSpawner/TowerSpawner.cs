using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private TowerController towerPrefab;

    public void TowerSpawn(Vector3 position, TowerData towerData) 
    {
        TowerController tower = Instantiate(towerPrefab, position, Quaternion.identity);
        tower.SetTowerData(towerData);
    }
}
