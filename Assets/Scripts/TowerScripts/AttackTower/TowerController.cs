using UnityEngine;

[RequireComponent(typeof(TowerDetect), typeof(TowerShoot),  typeof(TowerVisual))]
public class TowerController : MonoBehaviour
{
    private TowerData towerData;
    public TowerDetect towerDetect {  get; private set; }
    public TowerShoot towerShoot { get; private set; }
    public TowerVisual towerVisual { get; private set; }

    private void Awake()
    {
        InitializeComponent();
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

    public void SetTowerData(TowerData data) 
    {
        if (data == null) return;
        this.towerData = data;
        towerShoot.SetTowerData(towerData);
        towerDetect.Initialize(towerData);
        towerVisual.SetVisual(towerData.towerImage);
    }
}
