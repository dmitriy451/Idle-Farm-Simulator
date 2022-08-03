using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private int _timeForGrowth;
    
    private bool _matured = false;
    private void Start()
    {
        Growth();
    }
    private void Growth()
    {
        StartCoroutine(GrowthCoroutine());
    }

    IEnumerator GrowthCoroutine()
    {
        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(0.5f, 1, 0.5f);
        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(1.5f, 2, 1.5f);
        _matured = true;
    }
}
