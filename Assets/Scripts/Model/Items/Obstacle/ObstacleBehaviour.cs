using System;
using UnityEngine;

public sealed class ObstacleBehaviour : BaseItem
{
    public event Action<ObstacleBehaviour> OnDieChange;

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