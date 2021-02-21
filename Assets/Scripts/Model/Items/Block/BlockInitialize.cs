using System.Collections.Generic;
using UnityEngine;

public sealed class BlockInitialize
{
    private readonly BlockData _data;

    public readonly Vector3 spawnPoint;
    public readonly float speed;
    public readonly List<GameObject> prefabs;

    public BlockInitialize()
    {
        _data = Data.Instance.Block;

        speed = _data.speed;
        spawnPoint = _data.spawnPoint;
        prefabs = new List<GameObject>();

        for (var i = 0; i < _data.prefabs.Length; i++)
        {
            prefabs.Add(_data.prefabs[i]);
        }
    }
}