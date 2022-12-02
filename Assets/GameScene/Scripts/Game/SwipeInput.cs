using System;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    private const float _deathZone = 80f;

    public event Action<SwipeDirection> SwipeEvent;

    private Vector2 _startPosition;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                _startPosition = Input.GetTouch(0).position;

            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                ComputeSwipe(_startPosition, Input.GetTouch(0).position);
        }
    }

    private void ComputeSwipe(Vector2 startPosition, Vector2 endPosition)
    {
        Vector2 swipeVector = endPosition - startPosition;
        
        if (Vector2.SqrMagnitude(swipeVector) < _deathZone * _deathZone)
            return;

        float angle;

        if (swipeVector.y >= 0)
            angle = Vector2.Angle(swipeVector, new Vector2(1, 0));
        else
            angle = 360 - Vector2.Angle(swipeVector, new Vector2(1, 0));

        SwipeEvent?.Invoke(GetSwipeDirection(angle));
    }

    private SwipeDirection GetSwipeDirection(float angle)
    {
        if (360 <= angle || angle < 0)
            throw new ArgumentException();

        if (((float)DisplaySection.RightUp > angle && angle >= (float)DisplaySection.Right)
         || ((float)DisplaySection.RightDown < angle))
            return SwipeDirection.Right;

        else if ((float)DisplaySection.LeftUp > angle && angle >= (float)DisplaySection.RightUp)
            return SwipeDirection.Up;

        else if ((float)DisplaySection.LeftDown > angle && angle >= (float)DisplaySection.LeftUp)
            return SwipeDirection.Left;

        else
            return SwipeDirection.Down;
    }
}
