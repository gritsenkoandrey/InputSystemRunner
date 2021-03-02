using System.Collections.Generic;
using UnityEngine;

public sealed class BlockInitialize
{
    private readonly BlockData _data;

    public readonly float speed;
    public readonly List<Vector3> spawnPoints = new List<Vector3>();
    public readonly List<GameObject> prefabs = new List<GameObject>();

    public BlockInitialize()
    {
        _data = Data.Instance.Block;
        speed = _data.speed;

        for (var i = 0; i < _data.prefabs.Length; i++)
        {
            prefabs.Add(_data.prefabs[i]);
        }

        for (var i = 0; i < _data.spawnPoints.Length; i++)
        {
            spawnPoints.Add(_data.spawnPoints[i]);
        }
    }
}