using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveState : PlayerState
{
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private Transform _bag;
    [SerializeField] private float _speed;

    private Sequence sequence;
    private Vector3 direction = new Vector3();
    private void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(_bag.DOLocalRotate(new Vector3(0, 0, -10), 0.4f).SetEase(Ease.Linear));
        sequence.Append(_bag.DOLocalRotate(new Vector3(0, 0, 0), 0.4f).SetEase(Ease.Linear));
        sequence.Append(_bag.DOLocalRotate(new Vector3(0, 0, 10), 0.4f).SetEase(Ease.Linear));
        sequence.Append(_bag.DOLocalRotate(new Vector3(0, 0, 0), 0.4f).SetEase(Ease.Linear));
        sequence.SetLoops(-1);
    }
    private void OnEnable()
    {
        Animator.SetTrigger("Run");
        sequence.Restart();
        sequence.Play();
    }
    private void OnDisable()
    {
        sequence.Pause();
        _bag.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
    }
    private void FixedUpdate()
    {
        direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        Rigidbody.velocity = direction * _speed;

        transform.LookAt(transform.position + direction);
        
    }
}
