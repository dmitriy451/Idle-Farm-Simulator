using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArea : MonoBehaviour
{
    [SerializeField] private Transform _sellTransform;
    [SerializeField] private Wallet _wallet;
    public void Sell(BlockOfWheat blockOfWheat)
    {
        if (blockOfWheat!= null)
        {
            destroyBlock(blockOfWheat);
        }
    }
    private void destroyBlock(BlockOfWheat blockOfWheat)
    {
        _wallet.AddCoin(15);
        blockOfWheat.transform.DOMove(_sellTransform.position, 1);
        Destroy(blockOfWheat.gameObject, 1);
    }
}
