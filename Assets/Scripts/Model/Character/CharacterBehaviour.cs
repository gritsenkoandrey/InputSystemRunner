using UnityEngine;

[RequireComponent (typeof(BoxCollider), typeof(Rigidbody), typeof(Animator))]
public sealed class CharacterBehaviour : BaseModel
{
    private CharacterInitialize _init;

    private Rigidbody _body;
    private Animator _animator;

    private void Awake()
    {
        _init = new CharacterInitialize();

        _body = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        IsActive = true;
    }

    private void OnDisable()
    {
        IsActive = false;
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out obstacle))
        {
            obstacle.Destroy();
            EventBus.RaiseEvent<ICollision>(h => h.PickObstacle());
        }
        else if (target.TryGetComponent(out block))
        {
            Damage();
            EventBus.RaiseEvent<ICollision>(h => h.PickBlock());
        }
        else if (target.TryGetComponent(out coin))
        {
            coin.Destroy();
            EventBus.RaiseEvent<ICollision>(h => h.PickCoin());
        }
    }

    private void Damage()
    {
        Services.Instance.CameraServices.CreateShake(ShakeType.Low);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _init.rayDis, LayerHelper.GroundLayer);
    }

    public void Jump()
    {
        if (CheckGround())
        {
            _body.AddForce(Vector3.up * _init.jump, ForceMode.Impulse);
            _animator.SetTrigger(AnimationNameHelper.JUMP_ANIMATION);
        }
    }

    public void Move(float input)
    {
        if (CheckGround())
        {
            var tempPos = transform.position;

            if (Mathf.Approximately(tempPos.z, _init.middlePos))
            {
                _body.MovePosition(Vector3.forward * input * _init.speed);
            }
            else if (Mathf.Approximately(tempPos.z, _init.minPos) && input > 0 || Mathf.Approximately(tempPos.z, _init.maxPos) && input < 0)
            {
                _body.MovePosition(Vector3.zero);
            }
        }
    }
}