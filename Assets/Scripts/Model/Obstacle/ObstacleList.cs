using System.Collections.Generic;


public static class ObstacleList
{
    private static List<ObstacleModel> _obstacleList;

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

    public static void Execute()
    {
        for (int i = 0; i < _obstacleList.Count; i++)
        {
            _obstacleList[i].Move();
        }
    }
}
