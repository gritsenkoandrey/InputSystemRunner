using UnityEngine;

public sealed class SpawnController : BaseController, IInitialization, IFixExecute, ICleanUp
{
    private readonly BlockInitialize _block;
    private readonly CoinInitialize _coin;
    private readonly ObstacleInitialize _obstacle;

    private readonly TimeRemaining _timeRemainingSpawn;
    private readonly float _timeToNextSpawn = 0.5f;

    private readonly CustomRandom _customRandom;
    private int _random;

    private readonly int _count = 5;

    public SpawnController()
    {
        _block = new BlockInitialize();
        _coin = new CoinInitialize();
        _obstacle = new ObstacleInitialize();

        _customRandom = new CustomRandom();
        _timeRemainingSpawn = new TimeRemaining(Spawn, _timeToNextSpawn, true);
    }

    public void Initialization()
    {
        CreatePool();
        StartSpawn();
    }

    public void FixedExecute()
    {
        ObstacleList.Execute(_obstacle.speed);
        BlockList.Execute(_block.speed);
        CoinList.Execute(_coin.speed);
    }

    private void CreatePool()
    {
        for (var i = 0; i < _obstacle.prefabs.Count; i++)
        {
            PoolManager.WarmPool(_obstacle.prefabs[i], _count);
        }

        for (var i = 0; i < _block.prefabs.Count; i++)
        {
            PoolManager.WarmPool(_block.prefabs[i], _count);
        }

        for (var i = 0; i < _coin.prefabs.Count; i++)
        {
            PoolManager.WarmPool(_coin.prefabs[i], _count);
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
        _random = _customRandom.Range(0, 10);

        if (_random > 4)
        {
            var obstacle = PoolManager.SpawnObject(_obstacle.prefabs[_customRandom.Range(0, _obstacle.prefabs.Count)],
                _obstacle.spawnPoints[_customRandom.Range(0, _obstacle.spawnPoints.Count)], Quaternion.identity).GetComponent<ObstacleBehaviour>();
            ObstacleList.AddObstacleToList(obstacle);
        }
        else if (_random < 3)
        {
            var block = PoolManager.SpawnObject(_block.prefabs[_customRandom.Range(0, _block.prefabs.Count)],
                _block.spawnPoint, Quaternion.identity).GetComponent<BlockBehaviour>();
            BlockList.AddBlockToList(block);
        }
        else if (_random == 3 || _random == 4)
        {
            var coin = PoolManager.SpawnObject(_coin.prefabs[_customRandom.Range(0, _coin.prefabs.Count)],
                _coin.spawnPoints[_customRandom.Range(0, _coin.spawnPoints.Count)], Quaternion.identity).GetComponent<CoinBehaviour>();
            CoinList.AddCoinToList(coin);
        }
    }

    public void Cleaner()
    {
        StopSpawn();

        ObstacleList.ClearList();
        BlockList.ClearList();
        CoinList.ClearList();
    }
}   