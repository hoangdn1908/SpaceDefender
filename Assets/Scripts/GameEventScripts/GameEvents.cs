using System;

public static class GameEvents 
{
    // Towers
    public static Action<PlatformController> OnPlatformSelected;
    public static Action<TowerData> OnTowerSelected;
    public static Action<PlatformController, TowerData> OnTowerBuilt;

    // Enemies
    public static Action<EnemyController> OnEnemySpawned;
    public static Action<EnemyController> OnEnemyFinished;
    public static Action<int> OnEnemyDied;
    

    // Player
    public static Action<int> OnPlayerHealthChanged;

    // Wallet
    public static Action<int> OnCoinChanged;

    // Wave
    public static Action<int, int> OnWaveChanged;

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

    public static void RaiseEnemyDied(int coin) 
    {
        OnEnemyDied?.Invoke(coin);
    }
    #endregion

    #region Player
    public static void RaisePlayerHealthChanged(int currentHealth) 
    {
        OnPlayerHealthChanged?.Invoke(currentHealth);
    }
    #endregion

    #region Coin
    public static void RaiseCoinChanged(int coin) 
    {
        OnCoinChanged?.Invoke(coin);
    }
    #endregion

    #region Wave
    public static void RaiseWaveChanged(int currentWave, int maxWave) 
    {
        OnWaveChanged?.Invoke(currentWave, maxWave);
    }
    #endregion
}
