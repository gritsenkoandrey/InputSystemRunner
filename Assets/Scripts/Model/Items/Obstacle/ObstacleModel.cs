using System;
using UnityEngine;

public sealed class ObstacleModel : BaseItem
{
    public event Action<ObstacleModel> OnDieChange;

    public override void Move(float speed)
    {
        transform.Translate(new Vector3(speed, 0f, 0f));
    }

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }
}