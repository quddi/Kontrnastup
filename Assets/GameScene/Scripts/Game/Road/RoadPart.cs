using UnityEngine;
using System;

[RequireComponent(typeof(RoadMovement))]
public class RoadPart : MonoBehaviour
{
    [SerializeField] private RoadSO _scriptableObject;
    [SerializeField] private Transform _endDownRightCorner;

    [SerializeField] private Transform _startDownRightCorner;
    [SerializeField] private Transform _origin;

    [SerializeField] private GameObject[] _coins;

    private RoadMovement _movement;

    public event Action BorderCrossedEvent;

    public RoadSO Type => _scriptableObject;

    public RoadSO[] CompatiblePartTypes => _scriptableObject.CompatibleParts;

    public Vector3 EndCorner => _endDownRightCorner.position;

    public Vector3 Displacement => _origin.position - _startDownRightCorner.position;


    private void Awake()
    {
        _movement = GetComponent<RoadMovement>();
    }

    private void OnCrossedBorder()
    {
        BorderCrossedEvent?.Invoke();
    }

    public void Spawn(Vector3 position)
    {
        transform.position = position + Displacement;
        ResetCoins();
        gameObject.SetActive(true);
    }

    public void Dispawn()
    {
        gameObject.SetActive(false);
    }

    private void ResetCoins()
    {
        foreach (var coin in _coins)
            coin.SetActive(true);
    }

    private void OnEnable()
    {
        _movement.BorderCrossedEvent += OnCrossedBorder;
    }

    private void OnDisable()
    {
        _movement.BorderCrossedEvent -= OnCrossedBorder;
    }
}
