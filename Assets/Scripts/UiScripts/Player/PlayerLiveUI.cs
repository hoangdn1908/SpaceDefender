using TMPro;
using UnityEngine;

public class PlayerLiveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI liveText;

    private void OnEnable()
    {
        GameEvents.OnPlayerHealthChanged += UpdateLiveText;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerHealthChanged -= UpdateLiveText;
    }

    private void UpdateLiveText(int currentHealth) 
    {
        liveText.text = "Lives: " + currentHealth;
    }
}
