using UnityEngine;
using System;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _runAnimation;
    [SerializeField] private GameObject _jumpAnimation;
    [SerializeField] private GameObject _rollAnimation;

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

        _movement.Roll(() => 
        {
            _rollAnimation.SetActive(false);
            _runAnimation.SetActive(true);
            modelCallback();
        });
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
