using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private ObjectPool projectilePool;
    private float fireTimer;
    private TowerData towerData;

    public void SetTowerData(TowerData towerData)
    {
        this.towerData = towerData;
    }
    public bool TryShoot(Transform target) 
    {
        fireTimer += Time.deltaTime;
        if (target == null) return false;
        if (fireTimer < towerData.timeRate) return false;
        Shoot(target);
        AudioManager.instance.PlayTowerSfx(towerData.fireSound);
        fireTimer = 0;
        return true;
    }

    private void Shoot(Transform target) 
    {
        GameObject projectileObject = projectilePool.GetFromPool();
        projectileObject.transform.position = firePos.position;
        ProjectileController projectile = projectileObject.GetComponent<ProjectileController>();
        // Set projectile value then shoot
        projectile.PrepareBeforeShoot(towerData.projectileSpeed, towerData.projectileDamage, projectilePool);
        projectile.SetSacle(new Vector3(towerData.scaleX, towerData.scaleY));
        projectile.Shoot(GetDirection(target));
    }

    private Vector2 GetDirection(Transform target) 
    {
        return (target.position - firePos.position).normalized;
    }
}
