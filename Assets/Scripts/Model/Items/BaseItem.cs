using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseItem : BaseModel
{
    private TimeRemaining _timeRemainingDestroyAfterTime;
    private readonly float _timeToDestroy = 3.75f;

    private void Awake()
    {
        _timeRemainingDestroyAfterTime = new TimeRemaining(Destroy, _timeToDestroy);
    }

    private void OnEnable()
    {
        _timeRemainingDestroyAfterTime.AddTimeRemaining();
    }

    private void OnDisable()
    {
        _timeRemainingDestroyAfterTime.RemoveTimeRemaining();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out character))
        {
            Destroy();
            Collision();
        }
    }

    public virtual void Move(float speed)
    {
        transform.Translate(new Vector3(speed, 0f, 0f));
    }

    public abstract void Destroy();
    public abstract void Collision();
}