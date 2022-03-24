using UnityEngine;
using TMPro;

public class UIWavePresenter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] EnemySpawner enemySpawner;

    void Start()
    {
        enemySpawner.onLoopChange += UpdateUI;
        UpdateUI();
    }

   

    private void UpdateUI()
    {
        int loopNumber = enemySpawner.GetCurrentWaveNumber();
        waveText.text = $"Wave: {loopNumber}";
    }

}
