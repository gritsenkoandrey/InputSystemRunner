using System.Collections.Generic;
using UnityEngine;

public sealed class SpawnController : BaseController, IInitialization, IExecute
{
    // Obstacle
    private readonly ObstacleData _obstacleData;
    private ObstacleModel _obstacle;
    private readonly List<Vector3> _listSpawnPointsObstacles;
    private readonly List<GameObject> _listPrefabsObstacles;
    private readonly byte _countObstacles = 5;
    private readonly float _speedObstacle;

    // Block
    private readonly BlockData _blockData;
    private BlockModel _block;
    private readonly List<GameObject> _listPrefabsBlocks;
    private readonly byte _countBlocks = 5;
    private readonly float _speedBlock;

    // Timer
    private readonly TimeRemaining _timeRemainingSpawn;
    private readonly float _timeToNextSpawn = 0.5f;

    // Random
    private readonly FastRandom _random;

    public SpawnController()
    {
        _obstacleData = Data.Instance.Obstacle;
        _speedObstacle = _obstacleData.speed;

        _blockData = Data.Instance.Block;
        _speedBlock = _blockData.speed;

        _listSpawnPointsObstacles = new List<Vector3>();
        for (var i = 0; i < _obstacleData.spawnPoints.Length; i++)
        {
            _listSpawnPointsObstacles.Add(_obstacleData.spawnPoints[i]);
        }

        _listPrefabsObstacles = new List<GameObject>();
        for (var i = 0; i < _obstacleData.prefabs.Length; i++)
        {
            _listPrefabsObstacles.Add(_obstacleData.prefabs[i]);
        }

        _listPrefabsBlocks = new List<GameObject>();
        for (var i = 0; i < _blockData.prefabs.Length; i++)
        {
            _listPrefabsBlocks.Add(_blockData.prefabs[i]);
        }

        _random = new FastRandom();
        _timeRemainingSpawn = new TimeRemaining(Spawn, _timeToNextSpawn, true);
    }

    public void Initialization()
    {
        CreatePoolObject();
        StartSpawn();
    }

    public void Execute()
    {
        ObstacleList.Execute(_speedObstacle);
        BlockList.Execute(_speedBlock);
    }

    private void CreatePoolObject()
    {
        for (var i = 0; i < _listPrefabsObstacles.Count; i++)
        {
            PoolManager.WarmPool(_listPrefabsObstacles[i], _countObstacles);
        }

        for (var i = 0; i < _listPrefabsBlocks.Count; i++)
        {
            PoolManager.WarmPool(_listPrefabsBlocks[i], _countBlocks);
        }
    }

    private void StartSpawn()
    {
        _timeRemainingSpawn.AddTimeRemaining();
    }

    private void StopSpawn()
    {
        _timeRemainingSpawn.RemoveTimeRemaining();
    }

    private void Spawn()
    {
        if (_random.Range(0, 10) > 2)
        {
            _obstacle = PoolManager.SpawnObject(_listPrefabsObstacles[_random.Range(0, _listPrefabsObstacles.Count)],
                _listSpawnPointsObstacles[_random.Range(0, _listSpawnPointsObstacles.Count)], Quaternion.identity).GetComponent<ObstacleModel>();
            ObstacleList.AddObstacleToList(_obstacle);
        }
        else
        {
            _block = PoolManager.SpawnObject(_listPrefabsBlocks[_random.Range(0, _listPrefabsBlocks.Count)],
                _blockData.spawnPoint, Quaternion.identity).GetComponent<BlockModel>();
            BlockList.AddBlockToList(_block);
        }
    }
}