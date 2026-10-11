using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public static PlayerWallet instance;
    private int currentCoin;

    private void Awake()
    {
        if (!TrySetSingleton()) return;
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += AddCoin;    
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= AddCoin;
    }

    private bool TrySetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return false;
        }
        instance = this;
        return true;
    }

    public void SetCurrentCoin(int startCoin) 
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
