using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;

    private void OnEnable()
    {
        GameEvents.OnWaveChanged += UpdateWaveTextUI;
    }

    private void OnDisable()
    {
        GameEvents.OnWaveChanged -= UpdateWaveTextUI;
    }

    private void UpdateWaveTextUI(int currentWave, int maxWave) 
    {
        if (currentWave + 1 < maxWave)
            waveText.text = "Wave: " + (currentWave + 1);
        else
            waveText.text = "Wave: Final";
    }
}
