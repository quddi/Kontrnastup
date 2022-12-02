using UnityEngine;
using System;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private CollisionListener _playerCollisionDetector;

    public event Action GameEndEvent;

    private void Start()
    {
        PauseController.Unpause();
    }

    private void OnPlayerCollidedBarrier()
    {
        GameEndEvent?.Invoke();
        PauseController.Pause();
    }

    private void OnEnable()
    {
        _playerCollisionDetector.BarrierCollisionEvent += OnPlayerCollidedBarrier;
    }

    private void OnDisable()
    {
        _playerCollisionDetector.BarrierCollisionEvent -= OnPlayerCollidedBarrier;
    }
}
