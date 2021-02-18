using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public sealed class CharacterHealth : CharacterBase
{
    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out obstacle))
        {
            obstacle.Destroy();
            EventBus.RaiseEvent<ICollision>(h => h.PickObstacle());
        }
        else if (target.TryGetComponent(out block))
        {
            characterAnimator.GetDamage();
            EventBus.RaiseEvent<ICollision>(h => h.PickBlock());
        }
        else if (target.TryGetComponent(out coin))
        {
            coin.Destroy();
            EventBus.RaiseEvent<ICollision>(h => h.PickCoin());
        }
    }
}