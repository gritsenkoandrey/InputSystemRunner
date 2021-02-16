using UnityEngine;


public class CharacterCollision : MonoBehaviour
{
    private ObstacleModel _obstacle;

    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out _obstacle))
        {
            _obstacle.DestroyAfterCollision();
        }
    }
}