using UnityEngine;

public class Barrier : MonoBehaviour, ICollisionable
{
    private CollisionListener _collisionListener;

    private void Start()
    {
        _collisionListener = CollisionListener.Instance;
    }

    public void React() => _collisionListener.OnBarrierCollision();
}