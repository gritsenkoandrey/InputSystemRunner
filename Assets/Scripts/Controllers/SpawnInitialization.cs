using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnInitialization : BaseController
{
    // Obstacle
    private readonly ObstacleData _obstacleData;
    protected ObstacleModel obstacle;
    protected readonly List<Vector3> spawnPointsObstacles;
    protected readonly List<GameObject> prefabsObstacles;
    protected readonly byte countObstacles = 5;
    protected readonly float speedObstacle;

    // Block
    private readonly BlockData _blockData;
    protected BlockModel block;
    protected readonly Vector3 spawnPointsBlocks;
    protected readonly List<GameObject> prefabsBlocks;
    protected readonly byte countBlocks = 3;
    protected readonly float speedBlock;

    // Coin
    private readonly CoinData _coinData;
    protected CoinModel coin;
    protected readonly List<Vector3> spawnPointsCoins;
    protected readonly List<GameObject> prefabsCoins;
    protected readonly byte countCoins = 3;
    protected readonly float speedCoin;

    protected SpawnInitialization()
    {
        //Init Obstacle
        _obstacleData = Data.Instance.Obstacle;
        speedObstacle = _obstacleData.speed;

        spawnPointsObstacles = new List<Vector3>();
        for (var i = 0; i < _obstacleData.spawnPoints.Length; i++)
        {
            spawnPointsObstacles.Add(_obstacleData.spawnPoints[i]);
        }

        prefabsObstacles = new List<GameObject>();
        for (var i = 0; i < _obstacleData.prefabs.Length; i++)
        {
            prefabsObstacles.Add(_obstacleData.prefabs[i]);
        }

        //Init Block
        _blockData = Data.Instance.Block;
        speedBlock = _blockData.speed;
        spawnPointsBlocks = _blockData.spawnPoint;

        prefabsBlocks = new List<GameObject>();
        for (var i = 0; i < _blockData.prefabs.Length; i++)
        {
            prefabsBlocks.Add(_blockData.prefabs[i]);
        }

        //Init Coin
        _coinData = Data.Instance.Coin;
        speedCoin = _blockData.speed;

        spawnPointsCoins = new List<Vector3>();
        for (var i = 0; i < _coinData.spawnPoints.Length; i++)
        {
            spawnPointsCoins.Add(_coinData.spawnPoints[i]);
        }

        prefabsCoins = new List<GameObject>();
        for (var i = 0; i < _coinData.prefabs.Length; i++)
        {
            prefabsCoins.Add(_coinData.prefabs[i]);
        }
    }
}