using System;

public static class GameEvents 
{
    public static Action<PlatformController> OnPlatformSelected;
    public static Action<TowerData> OnTowerSelected;
    public static Action<PlatformController, TowerData> OnTowerBuilt;

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
}
