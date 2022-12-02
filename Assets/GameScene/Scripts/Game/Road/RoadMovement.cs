using UnityEngine;
using System;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private float _velocity = 0.2f;
    [SerializeField] private float _borderX = -1f;
    [SerializeField] private GameEnder _gameEndPresenter;

    private Transform _transform;
    private bool _gameEnded;

    public event Action BorderCrossedEvent;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (_gameEnded == false)
            _transform.Translate(Vector3.left * _velocity);

        if (_transform.position.x < _borderX)
            BorderCrossedEvent?.Invoke();
    }

    private void OnEnable()
    {
        _gameEndPresenter.GameEndEvent += () => _gameEnded = true;
    }

    private void OnDisable()
    {
        _gameEndPresenter.GameEndEvent -= () => _gameEnded = true;
    }
}
