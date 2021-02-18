using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseItem : BaseModel
{
    private TimeRemaining _timeRemainingDestroyAfterTime;
    private readonly float _timeToDestroy = 3.75f;

    protected void Awake()
    {
        _timeRemainingDestroyAfterTime = new TimeRemaining(Destroy, _timeToDestroy);
    }

    protected void OnEnable()
    {
        _timeRemainingDestroyAfterTime.AddTimeRemaining();
    }

    protected void OnDisable()
    {
        _timeRemainingDestroyAfterTime.RemoveTimeRemaining();
    }

    public abstract void Move(float speed);
    public abstract void Destroy();
}