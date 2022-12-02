using System;
using UnityEngine;

public class CollisionListener : MonoBehaviour
{
    public static CollisionListener Instance { get; private set; }

    public event Action BarrierCollisionEvent;
    public event Action CoinCollisionEvent;
    public event Action BonusCollisionEvent;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void OnBarrierCollision()
    {
        BarrierCollisionEvent?.Invoke();
    }

    public void OnCoinCollision()
    {
        CoinCollisionEvent?.Invoke();
    }

    public void OnBonusCollision()
    {
        BonusCollisionEvent?.Invoke();
    }
}
