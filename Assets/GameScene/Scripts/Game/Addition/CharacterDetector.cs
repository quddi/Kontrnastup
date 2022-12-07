using System;
using UnityEngine;

public class CharacterDetector : MonoBehaviour, ICollisionable
{
    public Action PlayerEnteredEvent;

    public void React() => PlayerEnteredEvent?.Invoke();
}
