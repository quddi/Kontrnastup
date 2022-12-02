using UnityEngine;
using TMPro;

[RequireComponent(typeof(StatsCounter))]
public class StatsPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _coinsText;

    private StatsCounter _statsCounter;

    private void Start()
    {
        _statsCounter = GetComponent<StatsCounter>();
    }

    private void Update()
    {
        _scoreText.text = _statsCounter.Score.ToString();
        _coinsText.text = _statsCounter.CoinsCount.ToString();
    }
}
