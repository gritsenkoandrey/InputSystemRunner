using System;

public sealed class ObstacleBehaviour : BaseItem
{
    public event Action<ObstacleBehaviour> OnDieChange;

    public override void Destroy()
    {
        OnDieChange?.Invoke(this);
        PoolManager.ReleaseObject(gameObject);
    }

    public override void Collision()
    {
        Services.Instance.EffectService.CreateEffectWithColorObject(this, transform.position);
        Services.Instance.EventService.PickObstacle();
    }
}