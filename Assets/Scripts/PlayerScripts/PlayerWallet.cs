using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public static PlayerWallet instance;
    [SerializeField] private int startCoin;
    private int currentCoin;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetCurrentCoin();
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += AddCoin;    
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= AddCoin;
    }

    private void SetCurrentCoin() 
    {
        currentCoin = startCoin;
        ListenCoinChanged(currentCoin);
    }

    private void AddCoin(int coin) 
    {
        this.currentCoin += coin;
        ListenCoinChanged(currentCoin);
    }

    public bool TryBuyTower(int coin)
    {
        if (currentCoin < coin) return false;
        currentCoin -= coin;
        ListenCoinChanged(currentCoin);
        return true;
    }

    private void ListenCoinChanged(int currentCoin) 
    {
        GameEvents.RaiseCoinChanged(currentCoin);
    }
}
