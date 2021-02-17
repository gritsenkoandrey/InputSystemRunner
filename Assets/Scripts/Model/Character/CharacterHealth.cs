using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public sealed class CharacterHealth : CharacterBase
{
    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out obstacle))
        {
            EventBus.RaiseEvent<IPickItem>(h => h.PickItem());
            obstacle.DestroyObstacle();
        }
        else if (target.TryGetComponent(out block))
        {
            DealDamage(block.Damage);
        }
    }

    private void DealDamage(int damage)
    {
        health -= damage;
        characterAnimator.GetDamage();
        EventBus.RaiseEvent<IChangeHealth>(h => h.ChangeHealth(health));

        if (health <= 0)
        {
            Debug.Log("You Died");
        }
    }
}