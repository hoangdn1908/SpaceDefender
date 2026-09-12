using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private TowerDatabase towerDatabase;
    [SerializeField] private GameObject towerUIPanel;
    [SerializeField] private TowerCard towerCardPrefab;
    [SerializeField] private Transform cardContainer;

    private void OnEnable()
    {
        GameEvents.OnPlatformSelected += HandlePlatformSelected;
        GameEvents.OnTowerBuilt += HandleTowerBuilt;
    }

    private void OnDisable()
    {
        GameEvents.OnPlatformSelected -= HandlePlatformSelected;
        GameEvents.OnTowerBuilt -= HandleTowerBuilt;
    }

    #region Open/Close
    private void OpenPanel() 
    {
        towerUIPanel.SetActive(true);
    }

    private void ClosePanel() 
    {
        towerUIPanel.SetActive(false);
    }
    #endregion

    #region Create cards
    private void ClearCards() 
    {
        foreach (Transform child in cardContainer) 
        {
            Destroy(child.gameObject);
        }
    }

    private void CreateCards() 
    {
        foreach (TowerData towerData in towerDatabase.towerDatas) 
        {
            TowerCard towerCard = Instantiate(towerCardPrefab, cardContainer);
            towerCard.SetUpCard(towerData);
        }
    }
    #endregion

    #region Handle events
    private void HandlePlatformSelected(PlatformController platform) 
    {
        OpenPanel();
        ClearCards();
        CreateCards();
    }

    private void HandleTowerBuilt(PlatformController platform, TowerData towerData) 
    {
        ClosePanel();
    }
    #endregion
}
