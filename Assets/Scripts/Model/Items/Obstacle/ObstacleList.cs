﻿using System.Collections.Generic;


public static class ObstacleList
{
    private readonly static List<ObstacleModel> _obstacleList;

    static ObstacleList()
    {
        _obstacleList = new List<ObstacleModel>();
    }

    public static void AddObstacleToList(ObstacleModel obstacle)
    {
        if (!_obstacleList.Contains(obstacle))
        {
            _obstacleList.Add(obstacle);
            obstacle.OnDieChange += RemoveObstacleToList;
        }
    }

    private static void RemoveObstacleToList(ObstacleModel obstacle)
    {
        if (!_obstacleList.Contains(obstacle))
        {
            return;
        }
        obstacle.OnDieChange -= RemoveObstacleToList;
        _obstacleList.Remove(obstacle);
    }

    public static void Execute(float speed)
    {
        for (int i = 0; i < _obstacleList.Count; i++)
        {
            _obstacleList[i].Move(speed);
        }
    }

    public static void ClearList()
    {
        _obstacleList.Clear();
    }
}