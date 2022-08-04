using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class CollectBlocks : MonoBehaviour
{
    [SerializeField] private int _maxCollectedBlocks;
    [SerializeField] private Transform _bag;
    
    private List<BlockOfWheat> _blockOfWheats = new List<BlockOfWheat>();
    public event UnityAction<int, int> BlocksCountChanged;
    private void Start()
    {
        BlocksCountChanged.Invoke(_blockOfWheats.Count, _maxCollectedBlocks);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BlockOfWheat blockOfWheat))
        {
            PickUpBlock(blockOfWheat);
        }
    }
    private void PickUpBlock(BlockOfWheat blockOfWheat)
    {
        if (_blockOfWheats.Count < _maxCollectedBlocks)
        {
            blockOfWheat.transform.parent = _bag;
            blockOfWheat.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(blockOfWheat.GetComponent<BoxCollider>());
            if (_blockOfWheats.Count == 0)
            {
                blockOfWheat.transform.DOLocalMove(Vector3.zero, 1);
                blockOfWheat.transform.DOLocalRotate(Vector3.zero, 1);
                _blockOfWheats.Add(blockOfWheat);
            }
            else
            {

                blockOfWheat.transform.DOLocalMove(new Vector3(0, _blockOfWheats[_blockOfWheats.Count - 1].transform.localScale.y * _blockOfWheats.Count, 0), 1);
                blockOfWheat.transform.DOLocalRotate(Vector3.zero, 1);
                _blockOfWheats.Add(blockOfWheat);
            }
            BlocksCountChanged.Invoke(_blockOfWheats.Count, _maxCollectedBlocks);
        }
    }

    public bool DeleteLastBlock(out BlockOfWheat blockOfWheat)
    {
        if (_blockOfWheats.Count>0)
        {
            BlockOfWheat DeletedBlock = _blockOfWheats[_blockOfWheats.Count-1];
            DeletedBlock.transform.parent = null;
            _blockOfWheats.Remove(DeletedBlock);
            blockOfWheat = DeletedBlock;
            BlocksCountChanged.Invoke(_blockOfWheats.Count, _maxCollectedBlocks);

            return true;
        }
        else
        {
            blockOfWheat = null;
            return false;
        }
    }

}
