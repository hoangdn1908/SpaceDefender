using System.Collections.Generic;
using UnityEngine;

public class TowerDetect : MonoBehaviour
{
    [SerializeField] private CircleCollider2D detectCollider;
    public Transform CurrentTarget {  get; private set; }
    private readonly List<Transform> enemyInRange = new List<Transform>();
    private TowerData towerData;

    public void Initialize(TowerData towerData) 
    {
        this.towerData = towerData;
        SetDetectRadius();
    }

    private void SetDetectRadius() 
    {
        detectCollider.radius = towerData.detectRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        if (!enemyInRange.Contains(collision.transform)) 
        {
            enemyInRange.Add(collision.transform);
            UpdateTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        enemyInRange.Remove(collision.transform);
        UpdateTarget();
    }

    private void UpdateTarget() 
    {
        if (enemyInRange.Count == 0) 
        {
            CurrentTarget = null;
            return;
        }
        CurrentTarget = enemyInRange[0];
    }
}
