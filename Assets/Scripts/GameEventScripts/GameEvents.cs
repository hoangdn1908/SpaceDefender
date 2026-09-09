using System;

public static class GameEvents 
{
    #region Choose tower
    public static Action<PlatformController> OnPlatformSelected;
    public static Action<TowerData> OnTowerSelected;
    public static Action<PlatformController, TowerData> OnTowerBuilt;
    #endregion

    #region Register enemies
    public static Action<EnemyController> OnEnemySpawned;
    public static Action<EnemyController> OnEnemyFinished;
    #endregion


    #region Tower
    public static void RaisePlatformSelected(PlatformController platform) 
    {
        OnPlatformSelected?.Invoke(platform);
    }

    public static void RaiseTowerSelected(TowerData towerData) 
    {
        OnTowerSelected?.Invoke(towerData);
    }

    public static void RaiseTowerBuilt(PlatformController platform, TowerData towerData) 
    {
        OnTowerBuilt?.Invoke(platform, towerData);
    }
    #endregion

    #region Enemies
    public static void RaiseEnemySpawned(EnemyController enemyController) 
    {
        OnEnemySpawned?.Invoke(enemyController);
    }

    public static void RaiseEnemyFinished(EnemyController enemyController) 
    {
        OnEnemyFinished?.Invoke(enemyController);
    }
    #endregion
}
