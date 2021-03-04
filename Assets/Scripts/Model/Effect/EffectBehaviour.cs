public sealed class EffectBehaviour : BaseModel
{
    private TimeRemaining _timeRemainingReturnToPool;
    private readonly float _timeReturnToPool = 1.0f;

    private void Awake()
    {
        _timeRemainingReturnToPool = new TimeRemaining(Destroy, _timeReturnToPool);
    }

    private void OnEnable()
    {
        _timeRemainingReturnToPool.AddTimeRemaining();
    }

    private void OnDisable()
    {
        _timeRemainingReturnToPool.RemoveTimeRemaining();
    }

    private void Destroy()
    {
        PoolManager.ReleaseObject(gameObject);
    }
}