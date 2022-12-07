using UnityEngine;
using System;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private float _velocity = 0.2f;

    private GameEnder _gameEnder;
    private Transform _transform;
    private bool _gameEnded;

    private void Awake()
    {
        _gameEnder = GameEnder.Instance;
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (_gameEnded == false)
            _transform.Translate(Vector3.left * _velocity);
    }

    private void OnEnable()
    {
        _gameEnder.GameEndEvent += () => _gameEnded = true;
    }

    private void OnDisable()
    {
        _gameEnder.GameEndEvent -= () => _gameEnded = true;
    }
}
