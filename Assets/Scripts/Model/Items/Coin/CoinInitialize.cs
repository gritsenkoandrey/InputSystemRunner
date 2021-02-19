using System.Collections.Generic;
using UnityEngine;

public sealed class CoinInitialize
{
    private readonly CoinData _data;

    public readonly float speedCoin;
    public readonly List<Vector3> spawnPointsCoins;
    public readonly List<GameObject> prefabsCoins;

    public CoinInitialize()
    {
        _data = Data.Instance.Coin;
        speedCoin = _data.speed;
        spawnPointsCoins = new List<Vector3>();
        prefabsCoins = new List<GameObject>();

        for (var i = 0; i < _data.spawnPoints.Length; i++)
        {
            spawnPointsCoins.Add(_data.spawnPoints[i]);
        }

        for (var i = 0; i < _data.prefabs.Length; i++)
        {
            prefabsCoins.Add(_data.prefabs[i]);
        }
    }
}