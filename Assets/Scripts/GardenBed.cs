using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private Wheat _wheatPrefab;
    [SerializeField] private Transform _plantPosition;

    private Wheat _plantedWheat;

    private void Start()
    {
        Plant();
    }

    private void Update()
    {

        if (_plantedWheat == null)
        {
            Plant();
        }
    }
    private void Plant()
    {
        _plantedWheat = Instantiate(_wheatPrefab, _plantPosition.position, Quaternion.identity, transform);
    }
}
