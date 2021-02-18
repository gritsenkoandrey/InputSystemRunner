using System.Collections.Generic;

public static class BlockList
{
    private readonly static List<BlockModel> _blockList;

    static BlockList()
    {
        _blockList = new List<BlockModel>();
    }

    public static void AddBlockToList(BlockModel block)
    {
        if (!_blockList.Contains(block))
        {
            _blockList.Add(block);
            block.OnDieChange += RemoveBlockToList;
        }
    }

    private static void RemoveBlockToList(BlockModel block)
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
        for (int i = 0; i < _blockList.Count; i++)
        {
            _blockList[i].Move(speed);
        }
    }
    public static void ClearList()
    {
        _blockList.Clear();
    }

}