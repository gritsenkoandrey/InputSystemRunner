using System.Collections.Generic;
using UnityEngine;

public sealed class ObstacleInitialize
{
    private readonly ObstacleData _data;

    public readonly float speedObstacle;
    public readonly List<Vector3> spawnPointsObstacles;
    public readonly List<GameObject> prefabsObstacles;

    public ObstacleInitialize()
    {
        _data = Data.Instance.Obstacle;
        speedObstacle = _data.speed;
        spawnPointsObstacles = new List<Vector3>();
        prefabsObstacles = new List<GameObject>();

        for (var i = 0; i < _data.spawnPoints.Length; i++)
        {
            spawnPointsObstacles.Add(_data.spawnPoints[i]);
        }

        for (var i = 0; i < _data.prefabs.Length; i++)
        {
            prefabsObstacles.Add(_data.prefabs[i]);
        }
    }
}