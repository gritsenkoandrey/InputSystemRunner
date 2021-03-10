using System;

public sealed class EventService : Service
{
    public event Action StartLevel;
    public event Action StopLevel;

    public event Action <CharacterType> OnCharacter;
    public event Action OffCharacter;

    public event Action OnBackground;
    public event Action OffBackground;

    public event Action StartSpawn;
    public event Action StopSpawn;

    public event Action OnPickObstacle;
    public event Action OnPickCoin;
    public event Action OnPickBlock;

    public event Action OnShowHaveCoins;

    public EventService()
    {
        StartLevel += delegate { };
        StopLevel += delegate { };

        OnCharacter += delegate { };
        OffCharacter += delegate { };

        OnBackground += delegate { };
        OffBackground += delegate { };

        StartSpawn += delegate { };
        StopSpawn += delegate { };

        OnPickObstacle += delegate { };
        OnPickCoin += delegate { };
        OnPickBlock += delegate { };

        OnShowHaveCoins += delegate { };
    }

    public void StartLevelTimer() => StartLevel?.Invoke();
    public void StopLevelTimer() => StopLevel?.Invoke();
    public void SpawnCharacter(CharacterType characterType) => OnCharacter?.Invoke(characterType);
    public void DestroyCharacter() => OffCharacter?.Invoke();
    public void SpawnBackground() => OnBackground?.Invoke();
    public void DestroyBackground() => OffBackground?.Invoke();
    public void StartSpawnItems() => StartSpawn?.Invoke();
    public void StopSpawnItems() => StopSpawn?.Invoke();
    public void PickObstacle() => OnPickObstacle?.Invoke();
    public void PickCoin() => OnPickCoin?.Invoke();
    public void PickBlock() => OnPickBlock?.Invoke();
    public void ShowHaveCoins() => OnShowHaveCoins?.Invoke();
}