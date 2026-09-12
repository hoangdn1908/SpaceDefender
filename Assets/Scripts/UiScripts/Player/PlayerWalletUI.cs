using TMPro;
using UnityEngine;

public class PlayerWalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        GameEvents.OnCoinChanged += UpdateCoinUI;
    }

    private void OnDisable()
    {
        GameEvents.OnCoinChanged -= UpdateCoinUI;
    }

    private void UpdateCoinUI(int currentCoin) 
    {
        coinText.text = "Coin: " + currentCoin;
    }
}
