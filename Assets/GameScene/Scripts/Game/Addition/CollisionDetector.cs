using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollisionable collisionable = other.GetComponent<ICollisionable>();
        if (collisionable != null)
            collisionable.React();
    }
}
