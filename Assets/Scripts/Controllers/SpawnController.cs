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
        CreatePool(_count);
        Services.Instance.EventService.StartSpawn += StartSpawn;
    }

    public void FixedExecute()
    {
        ObstacleList.Execute(_obstacle.speed);
        BlockList.Execute(_block.speed);
        CoinList.Execute(_coin.speed);
    }

    private void CreatePool(int count)
    {
        for (var i = 0; i < _obstacle.prefabs.Count; i++)
        {
            PoolManager.WarmPool(_obstacle.prefabs[i], count);
        }

        for (var i = 0; i < _block.prefabs.Count; i++)
        {
            PoolManager.WarmPool(_block.prefabs[i], count);
        }

        for (var i = 0; i < _coin.prefabs.Count; i++)
        {
            PoolManager.WarmPool(_coin.prefabs[i], count);
        }

        PoolManager.WarmPool(Services.Instance.EffectService.Particle, count);
    }

    private void StartSpawn()
    {
        _timeRemainingSpawn.AddTimeRemaining();
        Services.Instance.EventService.StartSpawn -= StartSpawn;
        Services.Instance.EventService.StopSpawn += StopSpawn;
    }

    private void StopSpawn()
    {
        _timeRemainingSpawn.RemoveTimeRemaining();
        Services.Instance.EventService.StopSpawn -= StopSpawn;
    }

    private void Spawn()
    {
        _random = _customRandom.Range(0, 10);

        if (_random > 4)
        {
            SpawnObstacle();
        }
        else if (_random < 3)
        {
            SpawnBlock();
        }
        else if (_random == 3 || _random == 4)
        {
            SpawnCoin();
        }
    }

    private void SpawnObstacle()
    {
        var obstacle = PoolManager.SpawnObject(_obstacle.prefabs[_customRandom.Range(0, _obstacle.prefabs.Count)],
            _obstacle.spawnPoints[_customRandom.Range(0, _obstacle.spawnPoints.Count)], Quaternion.identity).GetComponent<ObstacleBehaviour>();
        ObstacleList.AddObstacleToList(obstacle);
    }

    private void SpawnBlock()
    {
        var count = 0;

        for (var i = 0; i < _block.spawnPoints.Count; i++)
        {
            if (count == _block.prefabs.Count)
            {
                return;
            }

            _random = _customRandom.Range(0, _block.prefabs.Count + 1);
            if (_random == _block.prefabs.Count)
            {
                return;
            }

            if (_random == (int)BlockType.BigBlock)
            {
                count++;
            }

            var block = PoolManager.SpawnObject(_block.prefabs[_random],
                _block.spawnPoints[i], Quaternion.identity).GetComponent<BlockBehaviour>();
            BlockList.AddBlockToList(block);
        }
    }

    private void SpawnCoin()
    {
        var coin = PoolManager.SpawnObject(_coin.prefabs[_customRandom.Range(0, _coin.prefabs.Count)],
            _coin.spawnPoints[_customRandom.Range(0, _coin.spawnPoints.Count)], Quaternion.identity).GetComponent<CoinBehaviour>();
        CoinList.AddCoinToList(coin);
    }

    public void Cleaner()
    {
        ObstacleList.ClearList();
        BlockList.ClearList();
        CoinList.ClearList();
    }
}