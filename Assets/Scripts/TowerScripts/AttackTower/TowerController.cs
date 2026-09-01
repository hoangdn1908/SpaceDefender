using UnityEngine;

[RequireComponent(typeof(TowerDetect), typeof(TowerShoot),  typeof(TowerVisual))]
public class TowerController : MonoBehaviour
{
    public TowerData towerData;
    public TowerDetect towerDetect {  get; private set; }
    public TowerShoot towerShoot { get; private set; }
    public TowerVisual towerVisual { get; private set; }

    private void Awake()
    {
        InitializeComponent();
        SetTowerData();
    }

    private void Update()
    {
        towerShoot.TryShoot(towerDetect.CurrentTarget);
    }

    private void InitializeComponent() 
    {
        towerDetect = GetComponent<TowerDetect>();
        towerShoot = GetComponent<TowerShoot>();
        towerVisual = GetComponent<TowerVisual>();
    }

    private void SetTowerData() 
    {
        towerShoot.SetTowerData(towerData);
        towerDetect.Initialize(towerData);
        towerVisual.SetVisual(towerData.towerImage);
    }
}
