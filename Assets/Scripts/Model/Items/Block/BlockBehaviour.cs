using System;

public sealed class BlockBehaviour : BaseItem
{
    public event Action<BlockBehaviour> OnDieChange;

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }
}