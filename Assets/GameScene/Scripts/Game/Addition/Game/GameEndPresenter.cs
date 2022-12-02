using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(GameEnder))]
public class GameEndPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private StatsCounter _statsCounter;
    [SerializeField] private TMP_Text _endScoreText;

    private const string _endScoreMessage = "Ваш рахунок: ";

    private GameEnder _gameEnder;

    private void Awake()
    {
        _gameEnder = GetComponent<GameEnder>();
    }

    private void OnGameEnd()
    {
        _endMenu.SetActive(true);
        _gameUI.SetActive(false);
        _endScoreText.text = _endScoreMessage + _statsCounter.Score.ToString();
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
