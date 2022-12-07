using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    [Space(20)]
    [SerializeField] private float _jerkPosition;
    [SerializeField] private float _jerkDuration;
    [SerializeField] private AnimationCurve _jerkCurve;

    [Space(20)]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private AnimationCurve _jumpCurve;

    [Space(20)]
    [SerializeField] private float _landingEnd;
    [SerializeField] private float _landingDuration;
    [SerializeField] private AnimationCurve _landingCurve;

    [Space(20)]
    [SerializeField] private float _rollDuration;
    [SerializeField] private AnimationCurve _rollCurve;

    public void Jerk(RunningLine runningLine)
    {
        transform.DOMoveZ(_jerkPosition * (int)runningLine * -1, _jerkDuration)
            .SetEase(_jerkCurve);
    }

    public void Jump(Action callback)
    {
        Sequence jumpSequence = DOTween.Sequence();
        jumpSequence.Append(transform.DOMoveY(_jumpHeight, _jumpDuration).SetEase(_jumpCurve));

        jumpSequence.Append(transform.DOMoveY(_landingEnd, _landingDuration)
            .SetEase(_landingCurve)
            .OnComplete(() => callback.Invoke()));
    }

    private IEnumerator WaitLanding(Action action)
    {
        yield return new WaitForSeconds(_landingDuration);
        action.Invoke();
    }

    public void Roll(Action callback)
    {
        StartCoroutine("WaitRoll", callback);
    }

    private IEnumerator WaitRoll(Action action)
    {
        yield return new WaitForSeconds(_rollDuration);
        action.Invoke();
    }
}
