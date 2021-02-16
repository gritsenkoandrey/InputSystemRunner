using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public sealed class ObstacleModel : MonoBehaviour
{
    private ObstacleData _obstacleData;

    private TimeRemaining _timeRemainingDestroyAfterTime;
    private float _timeToDestroy;
    private float _speed;

    public event Action<ObstacleModel> OnDieChange;

    private void Awake()
    {
        InitializationData();
        _timeRemainingDestroyAfterTime = new TimeRemaining(DestroyAfterTime, _timeToDestroy);
    }

    private void OnEnable()
    {
        _timeRemainingDestroyAfterTime.AddTimeRemaining();
    }

    private void OnDisable()
    {
        _timeRemainingDestroyAfterTime.RemoveTimeRemaining();
    }

    private void DestroyAfterTime()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }

    public void Move()
    {
        transform.Translate(new Vector3(_speed, 0f, 0f));
    }

    public void DestroyAfterCollision()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }

    private void InitializationData()
    {
        _obstacleData = Data.Instance.Obstacle;
        _speed = _obstacleData.speed;
        _timeToDestroy = _obstacleData.timeToDestroy;
    }
}