using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : PlayerTransition
{
    [SerializeField] VariableJoystick _joystick;
    public override void Enable()
    {
    }

    private void Update()
    {
        if (_joystick.Direction.x + _joystick.Direction.y != 0)
        {
            NeedTransit = true;
        }
    }
}
