using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Canvas _canvas;
    [SerializeField] Image _coinPrefab;
    [SerializeField] Image _targetCoin;
    private int _coins;
    public void AddCoin(int AddedCoin)
    {
        if (AddedCoin>0)
        {
            _coins += AddedCoin;
            ThrowCoin();
        }
    }

    private void ThrowCoin()
    {
        Image coin = Instantiate(_coinPrefab, _canvas.transform);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(coin.rectTransform.DOMove(_targetCoin.rectTransform.position, 0.2f).OnComplete(() => _text.text = _coins.ToString()));
        Destroy(coin.gameObject, 0.2f);
        sequence.Append(_targetCoin.rectTransform.DOShakePosition(0.2f,20,1000,90));
        sequence.Play();
    }
}
