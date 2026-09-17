using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerWallet playerWallet;
    public PlayerData playerData;

    private void Start()
    {
        SetData();
    }

    public void SetData() 
    {
        playerHealth.SetCurrentHealth(playerData.maxHealth);
        playerWallet.SetCurrentCoin(playerData.startCoin);
    }
}
