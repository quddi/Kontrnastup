using UnityEngine;

[RequireComponent(typeof(StatsCounter))]
public class StatsSaver : MonoBehaviour
{
    [SerializeField] private GameEnder _gameEnder;
    
    private StatsCounter _statsCounter;

    private void Awake()
    {
        _statsCounter = GetComponent<StatsCounter>();
    }

    private void OnGameEnd()
    {
        SaveData();
    }

    private void SaveData()
    {
        DataResponsable.PlayerData.BestScore = Mathf.Max(DataResponsable.PlayerData.BestScore, _statsCounter.Score);
        DataResponsable.PlayerData.CoinsCount += _statsCounter.CoinsCount;
        DataResponsable.SaveData();
    }

    private void OnEnable()
    {
        _gameEnder.GameEndEvent += OnGameEnd;
    }

    private void OnDisable()
    {
        _gameEnder.GameEndEvent -= OnGameEnd;
    }
}