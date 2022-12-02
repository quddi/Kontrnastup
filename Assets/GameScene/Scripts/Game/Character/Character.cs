using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private SwipeInput _swipeInput;

    public RunningLine RunningLine { get; private set; }

    public event Action<Action> JumpEvent;
    public event Action<RunningLine> JerkEvent;
    public event Action<Action> RollEvent;

    private Action _animationCallback;

    private bool _canMove = true;

    private void Awake()
    {
        RunningLine = RunningLine.Middle;
        _animationCallback = () => _canMove = true;
    }

    private void OnSwipe(SwipeDirection swipeDirection)
    {
        if (PauseController.GamePaused == true)
            return;

        switch (swipeDirection)
        {
            case SwipeDirection.Right:
                if (RunningLine != RunningLine.Right)
                {
                    RunningLine++;
                    JerkEvent?.Invoke(RunningLine);
                }
                break;

            case SwipeDirection.Left:
                if (RunningLine != RunningLine.Left)
                {
                    RunningLine--;
                    JerkEvent?.Invoke(RunningLine);
                }
                break;

            case SwipeDirection.Up:
                if (_canMove)
                {
                    JumpEvent?.Invoke(_animationCallback);
                    _canMove = false;
                }
                break;

            case SwipeDirection.Down:
                if (_canMove)
                {
                    RollEvent?.Invoke(_animationCallback);
                    _canMove = false;
                }
                break;
        }
    }

    private void OnEnable()
    {
        _swipeInput.SwipeEvent += OnSwipe;
    }

    private void OnDisable()
    {
        _swipeInput.SwipeEvent -= OnSwipe;
    }
}
