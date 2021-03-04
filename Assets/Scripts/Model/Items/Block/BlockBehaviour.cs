using System;

public sealed class BlockBehaviour : BaseItem
{
    public event Action<BlockBehaviour> OnDieChange;

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(gameObject);
    }

    public override void Collision()
    {
        Services.Instance.EffectService.CreateEffectWithColorObject(this, transform.position);
        Services.Instance.EventService.PickBlock();
    }
}