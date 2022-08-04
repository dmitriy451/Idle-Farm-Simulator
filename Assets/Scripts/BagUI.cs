using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BagUI : MonoBehaviour
{
    [SerializeField] private CollectBlocks _collectBlocks;
    [SerializeField] private TMP_Text _view;
    private void OnEnable()
    {
        _collectBlocks.BlocksCountChanged += OnBlocksCountChanged;
    }

    private void OnBlocksCountChanged(int currentBlocks, int maxBlocks)
    {
        _view.text = $"{currentBlocks} / {maxBlocks}";
    }

    private void OnDisable()
    {
        _collectBlocks.BlocksCountChanged -= OnBlocksCountChanged;

    }

}
