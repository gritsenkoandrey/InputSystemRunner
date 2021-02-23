using System;

public sealed class CoinBehaviour : BaseItem
{
    public event Action<CoinBehaviour> OnDieChange;

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }
}