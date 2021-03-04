using System;

public sealed class CoinBehaviour : BaseItem
{
    public event Action<CoinBehaviour> OnDieChange;

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(gameObject);
    }

    public override void Collision()
    {
        Services.Instance.EffectService.CreateEffectWithColorObject(this, transform.position);
        Services.Instance.EventService.PickCoin();
    }
}