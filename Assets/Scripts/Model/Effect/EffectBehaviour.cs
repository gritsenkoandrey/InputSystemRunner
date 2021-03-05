public sealed class EffectBehaviour : BaseModel
{
    private TimeRemaining _timeRemainingDestroy;
    private readonly float _timeToDestroy = 1.0f;

    private void Awake()
    {
        _timeRemainingDestroy = new TimeRemaining(Destroy, _timeToDestroy);
    }

    private void OnEnable()
    {
        _timeRemainingDestroy.AddTimeRemaining();
    }

    private void OnDisable()
    {
        _timeRemainingDestroy.RemoveTimeRemaining();
    }

    private void Destroy()
    {
        PoolManager.ReleaseObject(gameObject);
    }
}