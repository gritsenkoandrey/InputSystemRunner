using System;
using UnityEngine;

public sealed class BlockModel : BaseItem
{
    private readonly byte _damage = 1;
    public byte Damage => _damage;

    public event Action<BlockModel> OnDieChange;

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