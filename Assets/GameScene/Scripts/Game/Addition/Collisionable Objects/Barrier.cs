using UnityEngine;

public class Barrier : MonoBehaviour, ICollisionable
{
    public void React() => CollisionListener.Instance.OnBarrierCollision();
}