using UnityEngine;

public sealed class SpawnController : SpawnInitialization, IInitialization, IExecute, ICleanUp
{
    private readonly TimeRemaining _timeRemainingSpawn;
    private readonly float _timeToNextSpawn = 0.5f;

    private readonly CustomRandom _customRandom;
    private int _random;

    public SpawnController()
    {
        _customRandom = new CustomRandom();
        _timeRemainingSpawn = new TimeRemaining(Spawn, _timeToNextSpawn, true);
    }

    public void Initialization()
    {
        CreatePoolObject();
        StartSpawn();
    }

    public void Execute()
    {
        ObstacleList.Execute(speedObstacle);
        BlockList.Execute(speedBlock);
        CoinList.Execute(speedCoin);
    }

    private void CreatePoolObject()
    {
        for (var i = 0; i < prefabsObstacles.Count; i++)
        {
            PoolManager.WarmPool(prefabsObstacles[i], countObstacles);
        }

        for (var i = 0; i < prefabsBlocks.Count; i++)
        {
            PoolManager.WarmPool(prefabsBlocks[i], countBlocks);
        }

        for (var i = 0; i < prefabsCoins.Count; i++)
        {
            PoolManager.WarmPool((prefabsCoins[i]), countCoins);
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
            obstacle = PoolManager.SpawnObject(prefabsObstacles[_customRandom.Range(0, prefabsObstacles.Count)],
                spawnPointsObstacles[_customRandom.Range(0, spawnPointsObstacles.Count)], Quaternion.identity).GetComponent<ObstacleModel>();
            ObstacleList.AddObstacleToList(obstacle);
        }
        else if (_random < 3)
        {
            block = PoolManager.SpawnObject(prefabsBlocks[_customRandom.Range(0, prefabsBlocks.Count)],
                spawnPointsBlocks, Quaternion.identity).GetComponent<BlockModel>();
            BlockList.AddBlockToList(block);
        }
        else if (_random == 3 || _random == 4)
        {
            coin = PoolManager.SpawnObject(prefabsCoins[_customRandom.Range(0, prefabsCoins.Count)],
                spawnPointsCoins[_customRandom.Range(0, spawnPointsCoins.Count)], Quaternion.identity).GetComponent<CoinModel>();
            CoinList.AddCoinToList(coin);
        }
    }

    public void Cleaner()
    {
        ObstacleList.ClearList();
        BlockList.ClearList();
        CoinList.ClearList();
        StopSpawn();
    }
}   