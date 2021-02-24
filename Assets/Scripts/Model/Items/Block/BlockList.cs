using System.Collections.Generic;
using UnityEngine;

public static class BlockList
{
    private readonly static List<BlockBehaviour> _blockList;

    static BlockList()
    {
        _blockList = new List<BlockBehaviour>();
    }

    public static void AddBlockToList(BlockBehaviour block)
    {
        if (!_blockList.Contains(block))
        {
            _blockList.Add(block);
            block.OnDieChange += RemoveBlockToList;
        }
    }

    private static void RemoveBlockToList(BlockBehaviour block)
    {
        if (!_blockList.Contains(block))
        {
            return;
        }
        block.OnDieChange -= RemoveBlockToList;
        _blockList.Remove(block);
    }

    public static void Execute(float speed)
    {
        for (var i = 0; i < _blockList.Count; i++)
        {
            _blockList[i].Move(speed);
        }
    }

    public static void ClearList()
    {
        _blockList.Clear();
    }
}