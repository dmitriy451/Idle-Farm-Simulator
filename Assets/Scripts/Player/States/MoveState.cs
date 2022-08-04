using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private float _speed;
    private Vector3 direction = new Vector3();
    private void OnEnable()
    {
        Animator.SetTrigger("Run");
    }

    private void FixedUpdate()
    {
        direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        Rigidbody.velocity = direction * _speed;

        transform.LookAt(transform.position + direction);
        
    }
}
