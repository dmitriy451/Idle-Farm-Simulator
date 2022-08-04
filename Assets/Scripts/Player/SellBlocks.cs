using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBlocks : MonoBehaviour
{
    [SerializeField] private CollectBlocks _collectBlocks;
    [SerializeField] private float _delayBetweenSell;
    [SerializeField] private float _timer;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out SellArea sellArea))
        {
            if (_timer <= 0)
            {
                Sell(sellArea);
                _timer = _delayBetweenSell;
            }
            _timer -= Time.deltaTime;
        }
    }
    void Sell(SellArea sellArea)
    {
        if (_collectBlocks.DeleteLastBlock(out BlockOfWheat blockOfWheat))
        {
            sellArea.Sell(blockOfWheat);
        }
    }
}
