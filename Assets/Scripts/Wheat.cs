using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private int _timeForGrowth;
    [SerializeField] private Transform _spikeletsOfWheat;
    [SerializeField] private Transform _particlePosition;
    [SerializeField] private BlockOfWheat _blockOfWheatPrefab;
    [SerializeField] private ParticleSystem _flindersParticles;

    private bool _matured = false;
    public bool Matured => _matured;
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
        yield return new WaitForSeconds(_timeForGrowth/2);
        _spikeletsOfWheat.transform.localScale = new Vector3(0.4f, 0.6f, 0.4f);
        yield return new WaitForSeconds(_timeForGrowth / 2);
        _spikeletsOfWheat.transform.localScale = new Vector3(1, 1, 1);
        _matured = true;
    }
    public void Mow()
    {
        if (_matured)
        {
            _spikeletsOfWheat.transform.localScale -= new Vector3(0,0.3f,0);
            Instantiate(_flindersParticles, _particlePosition.position, Quaternion.identity);
            if (_spikeletsOfWheat.transform.localScale.y <= 0.3f)
            {
                Destroy(this.gameObject);
                Instantiate(_blockOfWheatPrefab, _particlePosition.position, Quaternion.identity);
            }
        }
    }
}
