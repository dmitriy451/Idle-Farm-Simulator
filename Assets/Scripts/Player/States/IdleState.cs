using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    private void OnEnable()
    {
        Animator.SetTrigger("Idle");
    }
}
