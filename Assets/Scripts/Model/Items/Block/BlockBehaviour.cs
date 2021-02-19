using System;
using UnityEngine;

public sealed class BlockBehaviour : BaseItem
{
    public event Action<BlockBehaviour> OnDieChange;

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