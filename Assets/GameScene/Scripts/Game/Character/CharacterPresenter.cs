using UnityEngine;
using System;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _runAnimation;
    [SerializeField] private GameObject _jumpAnimation;
    [SerializeField] private GameObject _rollAnimation;

    [SerializeField] private GameObject _normalCollider;
    [SerializeField] private GameObject _rollCollider;

    private Character _character;
    private CharacterMovement _movement;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _movement = GetComponent<CharacterMovement>();
    }

    private void Jump(Action modelCallback)
    {
        _runAnimation.SetActive(false);
        _jumpAnimation.SetActive(true);

        _movement.Jump(() => 
        {
            _jumpAnimation.SetActive(false);
            _runAnimation.SetActive(true);
            modelCallback(); 
        });
    }

    private void Jerk(RunningLine runningLine)
    {
        _movement.Jerk(runningLine);
    }

    private void Roll(Action modelCallback)
    {
        _runAnimation.SetActive(false);
        _rollAnimation.SetActive(true);
        SetRollCollider();

        _movement.Roll(() => 
        {
            _rollAnimation.SetActive(false);
            _runAnimation.SetActive(true);
            SetNormalCollider();
            modelCallback();
        });
    }

    private void SetRollCollider()
    {
        _rollCollider.SetActive(true);
        _normalCollider.SetActive(false);
    }

    private void SetNormalCollider()
    {
        _rollCollider.SetActive(false);
        _normalCollider.SetActive(true);
    }

    private void OnEnable()
    {
        _character.JumpEvent += Jump;
        _character.JerkEvent += Jerk;
        _character.RollEvent += Roll;
    }

    private void OnDisable()
    {
        _character.JumpEvent -= Jump;
        _character.JerkEvent -= Jerk;
        _character.RollEvent -= Roll;
    }
}
