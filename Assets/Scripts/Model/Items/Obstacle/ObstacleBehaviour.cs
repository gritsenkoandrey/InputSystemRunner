using System;

public sealed class ObstacleBehaviour : BaseItem
{
    public event Action<ObstacleBehaviour> OnDieChange;

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(this.gameObject);
    }
}