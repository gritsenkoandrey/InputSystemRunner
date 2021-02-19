using System.Collections.Generic;
using UnityEngine;

public sealed class BlockInitialize
{
    private readonly BlockData _data;

    public readonly Vector3 spawnPointsBlocks;
    public readonly float speedBlock;
    public readonly List<GameObject> prefabsBlocks;

    public BlockInitialize()
    {
        _data = Data.Instance.Block;
        speedBlock = _data.speed;
        spawnPointsBlocks = _data.spawnPoint;
        prefabsBlocks = new List<GameObject>();

        for (var i = 0; i < _data.prefabs.Length; i++)
        {
            prefabsBlocks.Add(_data.prefabs[i]);
        }
    }
}