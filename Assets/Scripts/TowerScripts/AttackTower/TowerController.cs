using UnityEngine;

[RequireComponent(typeof(TowerDetect), typeof(TowerShoot))]
public class TowerController : MonoBehaviour
{
    public TowerData towerData;
    public TowerDetect towerDetect {  get; private set; }
    public TowerShoot towerShoot { get; private set; }

    private void Awake()
    {
        InitializeComponent();
        towerShoot.SetTowerData(towerData);
        towerDetect.Initialize(towerData);
    }

    private void Update()
    {
        towerShoot.TryShoot(towerDetect.CurrentTarget);
    }

    private void InitializeComponent() 
    {
        towerDetect = GetComponent<TowerDetect>();
        towerShoot = GetComponent<TowerShoot>();
    }
}
