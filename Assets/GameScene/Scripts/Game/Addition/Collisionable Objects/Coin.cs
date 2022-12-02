using UnityEngine;

public class Coin : MonoBehaviour, ICollisionable
{
    [SerializeField] private CollisionListener _collisionListener;

    public void React()
    {
        _collisionListener.OnCoinCollision();
        gameObject.SetActive(false);
    }
}
