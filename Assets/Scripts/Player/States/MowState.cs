using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowState : PlayerState
{
    [SerializeField] private GameObject _scythe;
    private void OnEnable()
    {
        Animator.SetTrigger("Mow");
        _scythe.SetActive(true);
    }
    private void OnDisable()
    {
        _scythe.SetActive(false);
    }
}
