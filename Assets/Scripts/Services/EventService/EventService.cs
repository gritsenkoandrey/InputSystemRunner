using System;

public sealed class EventService : Service
{
    public event Action OnStartTimer;
    public event Action OnStopTimer;
    public event Action<CharacterType> OnCharacterEnable;
    public event Action OnCharacterDisable;
    public event Action<bool> OnVisibleCharacter;
    public event Action<BackgroundType> OnBackgroundEnable;
    public event Action OnBackgroundDisable;
    public event Action OnStartSpawn;
    public event Action OnStopSpawn;
    public event Action OnPickObstacle;
    public event Action OnPickCoin;
    public event Action OnPickBlock;
    public event Action<int> OnHaveCoin;

    public EventService()
    {
        OnStartTimer += delegate { };
        OnStopTimer += delegate { };
        OnCharacterEnable += delegate { };
        OnCharacterDisable += delegate { };
        OnVisibleCharacter += delegate { };
        OnBackgroundEnable += delegate { };
        OnBackgroundDisable += delegate { };
        OnStartSpawn += delegate { };
        OnStopSpawn += delegate { };
        OnPickObstacle += delegate { };
        OnPickCoin += delegate { };
        OnPickBlock += delegate { };
        OnHaveCoin += delegate { };
    }

    public void StartTimer() => OnStartTimer?.Invoke();
    public void StopTimer() => OnStopTimer?.Invoke();
    public void EnableCharacter(CharacterType characterType) => OnCharacterEnable?.Invoke(characterType);
    public void DisableCharacter() => OnCharacterDisable?.Invoke();
    public void VisibleCharacter(bool value) => OnVisibleCharacter?.Invoke(value);
    public void EnableBackground(BackgroundType background) => OnBackgroundEnable?.Invoke(background);
    public void DisableBackground() => OnBackgroundDisable?.Invoke();
    public void StartSpawn() => OnStartSpawn?.Invoke();
    public void StopSpawn() => OnStopSpawn?.Invoke();
    public void PickObstacle() => OnPickObstacle?.Invoke();
    public void PickCoin() => OnPickCoin?.Invoke();
    public void PickBlock() => OnPickBlock?.Invoke();
    public void HaveCoin(int coins) => OnHaveCoin?.Invoke(coins);
}