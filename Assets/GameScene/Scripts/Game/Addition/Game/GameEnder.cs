using UnityEngine;
using System;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private CollisionListener _collisionListener;

    static public GameEnder Instance { get; private set; }

    public event Action GameEndEvent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

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
        _collisionListener.BarrierCollisionEvent += OnPlayerCollidedBarrier;
    }

    private void OnDisable()
    {
        _collisionListener.BarrierCollisionEvent -= OnPlayerCollidedBarrier;
    }
}
