using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private List<RoadPart> _inactiveRoadParts;
    [SerializeField] private int _roadPartsInGameCount;
    [SerializeField] private RoadBorder _roadBorder;
    [SerializeField] private RoadPart _startPart;

    private Queue<RoadPart> _activeRoadParts;

    private RoadPart _tailPart;

    public event Action<RoadPart, RoadPart> TailAddedEvent;
    public event Action<RoadPart> HeadRemovedEvent;

    private void Awake()
    {
        _activeRoadParts = new Queue<RoadPart>();

        AddStartPart();

        for (int i = 0; i < _roadPartsInGameCount - 1; i++)
            GenerateNext();
    }

    private void OnPartCrossedBorder()
    { 
        //Debug.Log("OnPartCrossedBorder " + Time.time); //------------------------
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    foreach (var part in _activeRoadParts)
        //        sb.AppendLine(part.ToString() + " ");
        //    Debug.Log(sb.ToString());
        //}
        GenerateNext();
        RemoveHeadPart();
    }

    private void AddStartPart()
    {
        _startPart.Spawn(Vector3.zero);

        _activeRoadParts.Enqueue(_startPart);

        _tailPart = _startPart;
    }

    public void GenerateNext()
    {
        //Debug.Log("generate start " + Time.time); //------------------------
        RoadSO chosenPartType = GetRandomCompatiblePart(_tailPart);

        RoadPart chosenPart = _inactiveRoadParts.FirstOrDefault(part => part.Type == chosenPartType);

        if (chosenPart == null)
        {
            foreach (var part in _inactiveRoadParts)
            {
                if (_tailPart.CompatiblePartTypes.Contains(part.Type))
                {
                    chosenPart = part;
                    break;
                }
            }
        }

       //if (chosenPart == null)
            //Debug.Log("chosen part was null!"); //-------------------------

        AddTailPart(chosenPart);
        //Debug.Log("generate end " + Time.time + " chosenPart:" + chosenPart.name); //------------------------
    }

    private void AddTailPart(RoadPart roadPart)
    {
        _inactiveRoadParts.Remove(roadPart);
        _activeRoadParts.Enqueue(roadPart);

        TailAddedEvent?.Invoke(roadPart, _tailPart);
        _tailPart = roadPart;
    }

    public void RemoveHeadPart()
    {
        //Debug.Log("remove head start " + Time.time); //------------------------

        RoadPart roadPart = _activeRoadParts.Dequeue();

        //Debug.Log("part to remove: " + roadPart.name); // --------------------
        
        _inactiveRoadParts.Add(roadPart);

        HeadRemovedEvent?.Invoke(roadPart);

        //Debug.Log("remove head end " + Time.time); //------------------------
    }

    private RoadSO GetRandomCompatiblePart(RoadPart roadPart)
    {
        RoadSO[] compatibleParts = roadPart.CompatiblePartTypes;

        return compatibleParts[UnityEngine.Random.Range(0, compatibleParts.Length)];
    }

    private void OnEnable()
    {
        _roadBorder.RoadPartExited += OnPartCrossedBorder;
    }

    private void OnDisable()
    {
        _roadBorder.RoadPartExited -= OnPartCrossedBorder;
    }
}
