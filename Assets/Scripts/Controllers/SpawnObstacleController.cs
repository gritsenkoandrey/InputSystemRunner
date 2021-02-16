using System.Collections.Generic;
using UnityEngine;

public sealed class SpawnObstacleController : IInitialization, IExecute
{
    private ObstacleData _obstacleData;

    private List<Vector3> _listSpawnPoints;
    private List<GameObject> _listPrefabsObstacles;

    private ObstacleModel _obstacle;
    private readonly byte _countObstacle = 10;

    private TimeRemaining _timeRemainingSpawn;
    private readonly float _timeToNextSpawn = 0.5f;

    public void Initialization()
    {
        InitializationData();
        PreSpawnObstacles();
        StartTimer();
    }

    public void Execute()
    {
        ObstacleList.Execute();
    }

    private void InitializationData()
    {
        _obstacleData = Data.Instance.Obstacle;

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
    }

    private void PreSpawnObstacles()
    {
        for (var i = 0; i < _listPrefabsObstacles.Count; i++)
        {
            PoolManager.WarmPool(_listPrefabsObstacles[i], _countObstacle);
        }
    }

    private void StartTimer()
    {
        _timeRemainingSpawn = new TimeRemaining(Spawn, _timeToNextSpawn, true);
        _timeRemainingSpawn.AddTimeRemaining();
    }

    private void RemoveTimer()
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