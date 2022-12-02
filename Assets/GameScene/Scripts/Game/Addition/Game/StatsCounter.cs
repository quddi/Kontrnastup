using UnityEngine;

public class StatsCounter : MonoBehaviour
{
    [SerializeField] private double _deltaScore;
    [SerializeField] private int _pickedCoinMutiplier;
    [SerializeField] private CollisionListener _collisionListener;

    private double _score;

    private int _coinsCount;

    public int Score => (int)_score;

    public int CoinsCount => _coinsCount;

    private void Start()
    {
        _score = 0.0;
        _coinsCount = 0;
    }

    private void FixedUpdate()
    {
        if (PauseController.GamePaused == false)
            _score += _deltaScore;
    }

    private void OnCoinPicked()
    {
        _coinsCount += _pickedCoinMutiplier;
    }

    private void OnEnable()
    {
        _collisionListener.CoinCollisionEvent += OnCoinPicked;
    }

    private void OnDisable()
    {
        _collisionListener.CoinCollisionEvent -= OnCoinPicked;
    }
}
