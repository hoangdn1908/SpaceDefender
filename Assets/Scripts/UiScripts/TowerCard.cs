using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerCard : MonoBehaviour
{
    [SerializeField] private Image towerImage;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button selectedBtn;
    private TowerData towerData; 

    public void SetUpCard(TowerData data) 
    {
        this.towerData = data;
        towerImage.sprite = towerData.towerImage;
        costText.text = towerData.cost.ToString();
        selectedBtn.onClick.RemoveAllListeners();
        selectedBtn.onClick.AddListener(SelectedTower);
    }

    private void SelectedTower() 
    {
        GameEvents.RaiseTowerSelected(towerData);
    }
}
