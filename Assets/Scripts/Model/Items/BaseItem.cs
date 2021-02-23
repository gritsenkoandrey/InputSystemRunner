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

    public virtual void Move(float speed)
    {
        transform.Translate(new Vector3(speed, 0f, 0f));
    }

    public abstract void Destroy();
}