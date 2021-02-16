using System.Collections.Generic;
using UnityEngine;

public sealed class SpawnController : BaseController, IInitialization, IExecute
{
    private readonly ObstacleData _obstacleData;
    private readonly List<Vector3> _listSpawnPoints;
    private readonly List<GameObject> _listPrefabsObstacles;

    private ObstacleModel _obstacle;
    private readonly byte _countObstacles = 10;

    private BlockModel _block;
    private readonly byte _countBlocks = 5;

    private readonly TimeRemaining _timeRemainingSpawn;
    private readonly float _timeToNextSpawn = 0.5f;

    private readonly float _speed;

    public SpawnController()
    {
        _obstacleData = Data.Instance.Obstacle;
        _speed = _obstacleData.speed;

        _listSpawnPoints = new List<Vector3>();
        for (var i = 0; i < _obstacleData.spawnPoints.Length; i++)
        {
            _listSpawnPoints.Add(_obstacleData.spawnPoints[i]);
        }

        _listPrefabsObstacles = new List<GameObject>();
        for (var i = 0; i < _obstacleData.prefabs.Length; i++)
        {
            _listPrefabsObstacles.Add(_obstacleData.prefabs[i]);
        }

        _timeRemainingSpawn = new TimeRemaining(Spawn, _timeToNextSpawn, true);
    }

    public void Initialization()
    {
        PoolObstacles();
        StartSpawn();
    }

    public void Execute()
    {
        ObstacleList.Execute(_speed);
        BlockList.Execute(_speed);
    }

    private void PoolObstacles()
    {
        for (var i = 0; i < _listPrefabsObstacles.Count; i++)
        {
            PoolManager.WarmPool(_listPrefabsObstacles[i], _countObstacles);
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
        _obstacle = PoolManager.SpawnObject(_listPrefabsObstacles[Random.Range(0, _listPrefabsObstacles.Count)],
            _listSpawnPoints[Random.Range(0, _listSpawnPoints.Count)], Quaternion.identity).GetComponent<ObstacleModel>();

        ObstacleList.AddObstacleToList(_obstacle);
    }
}