using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Road")]
public class RoadSO : ScriptableObject
{
    [SerializeField] private RoadSO[] _compatibleParts;

    public RoadSO[] CompatibleParts => _compatibleParts;
}
