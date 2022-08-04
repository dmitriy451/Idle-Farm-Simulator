using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockOfWheat : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.up + new Vector3(Random.Range(0f, 0.5f), 1, Random.Range(0f, 0.5f)) * _force, ForceMode.Impulse);
    }
}
