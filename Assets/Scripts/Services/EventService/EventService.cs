﻿using System;

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
    }

    public void StartTimer() => StartLevel?.Invoke();
    public void StopTimer() => StopLevel?.Invoke();
    public void SpawnCharacter(CharacterType characterType) => OnCharacter?.Invoke(characterType);
    public void DestroyCharacter() => OffCharacter?.Invoke();
    public void SpawnBackground() => OnBackground?.Invoke();
    public void DestroyBackground() => OffBackground?.Invoke();
    public void StartSpawnItems() => StartSpawn?.Invoke();
    public void StopSpawnItems() => StopSpawn?.Invoke();
}