using UnityEngine;

public class Coin : MonoBehaviour, ICollisionable
{
    public void React()
    {
        CollisionListener.Instance.OnCoinCollision();
        gameObject.SetActive(false);
    }
}
