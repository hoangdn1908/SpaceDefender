using UnityEngine;

public class PlatformLive : MonoBehaviour
{
    [SerializeField] private PlatformController platform;
    private void OnEnable()
    {
        GameEvents.OnTowerBuilt += HandleDisplay;
    }

    private void OnDisable()
    {
        GameEvents.OnTowerBuilt -= HandleDisplay;
    }

    private void HandleDisplay(PlatformController platformController, TowerData towerData) 
    {
        if (this.platform != platformController) return;
        platform.gameObject.SetActive(false);
    }
}
