using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    [SerializeField] private TowerSpawner towerSpawner;
    [SerializeField] private AudioClip towerPlacedSound;
    private PlatformController currentPlatform;

    private void OnEnable()
    {
        GameEvents.OnPlatformSelected += HandlePlatformSelected;
        GameEvents.OnTowerSelected += HandleTowerSelected;
    }

    private void OnDisable()
    {
        GameEvents.OnPlatformSelected -= HandlePlatformSelected;
        GameEvents.OnTowerSelected -= HandleTowerSelected;
    }

    #region Handle events
    private void HandlePlatformSelected(PlatformController platform) 
    {
        this.currentPlatform = platform;
    }

    private void HandleTowerSelected(TowerData towerData) 
    {
        if (currentPlatform == null) return;
        if (currentPlatform.IsOccupied) return;
        if (!PlayerWallet.instance.TryBuyTower(towerData.cost)) return;
        BuiltTower(currentPlatform, towerData);
        AudioManager.instance.PlaySfx(towerPlacedSound);
        currentPlatform = null;
    }
    #endregion

    private void BuiltTower(PlatformController platform, TowerData towerData) 
    {
        towerSpawner.TowerSpawn(platform.BuildPosition, towerData);
        platform.SetOccupied(true);
        GameEvents.RaiseTowerBuilt(platform, towerData);
    }
}
