using UnityEngine;

[RequireComponent(typeof(RoadGenerator))]
public class RoadPresenter : MonoBehaviour
{
    private RoadGenerator _roadGenerator;

    private void Awake()
    {
        _roadGenerator = GetComponent<RoadGenerator>();
    }

    private void OnTailAdded(RoadPart newTail, RoadPart previousPart)
    {
        Vector3 spawnPosition = previousPart.EndCorner;
        
        newTail.Spawn(spawnPosition);
    }

    private void OnHeadRemoved(RoadPart roadPart)
    {
        roadPart.Dispawn();
    }

    private void OnEnable()
    {
        _roadGenerator.TailAddedEvent += OnTailAdded;
        _roadGenerator.HeadRemovedEvent += OnHeadRemoved;
    }

    private void OnDisable()
    {
        _roadGenerator.TailAddedEvent -= OnTailAdded;
        _roadGenerator.HeadRemovedEvent -= OnHeadRemoved;
    }
}
