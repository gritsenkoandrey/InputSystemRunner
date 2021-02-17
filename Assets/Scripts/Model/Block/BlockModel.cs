using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public sealed class BlockModel : BaseModel
{
    private TimeRemaining _timeRemainingDestroyAfterTime;
    private readonly float _timeToDestroy = 3.75f;
    private readonly byte _damage = 1;

    public event Action<BlockModel> OnDieChange;
    public byte Damage => _damage;

    private void Awake()
    {
        _timeRemainingDestroyAfterTime = new TimeRemaining(DestroyObstacle, _timeToDestroy);
    }

    private void OnEnable()
    {
        _timeRemainingDestroyAfterTime.AddTimeRemaining();
    }

    private void OnDisable()
    {
        _timeRemainingDestroyAfterTime.RemoveTimeRemaining();
    }

    public void Move(float speed)
    {
        transform.Translate(new Vector3(speed, 0f, 0f));
    }

    public void DestroyObstacle()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }
}