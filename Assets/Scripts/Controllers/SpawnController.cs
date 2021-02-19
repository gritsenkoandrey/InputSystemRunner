using UnityEngine;

public sealed class SpawnController : BaseController, IInitialization, IExecute, ICleanUp
{
    private readonly BlockInitialize _blockInit;
    private readonly CoinInitialize _coinInit;
    private readonly ObstacleInitialize _obstacleInit;

    private readonly TimeRemaining _timeRemainingSpawn;
    private readonly float _timeToNextSpawn = 0.5f;

    private readonly CustomRandom _customRandom;
    private int _random;

    private readonly int _count = 5;
    public SpawnController()
    {
        _blockInit = new BlockInitialize();
        _coinInit = new CoinInitialize();
        _obstacleInit = new ObstacleInitialize();

        _customRandom = new CustomRandom();
        _timeRemainingSpawn = new TimeRemaining(Spawn, _timeToNextSpawn, true);
    }

    public void Initialization()
    {
        CreatePool(_count);
        StartSpawn();
    }

    public void Execute()
    {
        ObstacleList.Execute(_obstacleInit.speedObstacle);
        BlockList.Execute(_blockInit.speedBlock);
        CoinList.Execute(_coinInit.speedCoin);
    }

    private void CreatePool(int count)
    {
        for (var i = 0; i < _obstacleInit.prefabsObstacles.Count; i++)
        {
            PoolManager.WarmPool(_obstacleInit.prefabsObstacles[i], count);
        }

        for (var i = 0; i < _blockInit.prefabsBlocks.Count; i++)
        {
            PoolManager.WarmPool(_blockInit.prefabsBlocks[i], count);
        }

        for (var i = 0; i < _coinInit.prefabsCoins.Count; i++)
        {
            PoolManager.WarmPool(_coinInit.prefabsCoins[i], count);
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
            var obstacle = PoolManager.SpawnObject(_obstacleInit.prefabsObstacles[_customRandom.Range(0, _obstacleInit.prefabsObstacles.Count)],
                _obstacleInit.spawnPointsObstacles[_customRandom.Range(0, _obstacleInit.spawnPointsObstacles.Count)], Quaternion.identity).GetComponent<ObstacleBehaviour>();
            ObstacleList.AddObstacleToList(obstacle);
        }
        else if (_random < 3)
        {
            var block = PoolManager.SpawnObject(_blockInit.prefabsBlocks[_customRandom.Range(0, _blockInit.prefabsBlocks.Count)],
                _blockInit.spawnPointsBlocks, Quaternion.identity).GetComponent<BlockBehaviour>();
            BlockList.AddBlockToList(block);
        }
        else if (_random == 3 || _random == 4)
        {
            var coin = PoolManager.SpawnObject(_coinInit.prefabsCoins[_customRandom.Range(0, _coinInit.prefabsCoins.Count)],
                _coinInit.spawnPointsCoins[_customRandom.Range(0, _coinInit.spawnPointsCoins.Count)], Quaternion.identity).GetComponent<CoinBehaviour>();
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