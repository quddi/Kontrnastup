using UnityEngine;
using System;

public class RoadBorder : MonoBehaviour
{
    public event Action RoadPartExited;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<RoadPart>() != null)
            RoadPartExited?.Invoke();
    }
}
