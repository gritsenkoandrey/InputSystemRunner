using DG.Tweening;
using UnityEngine;

[RequireComponent (typeof(BoxCollider), typeof(Rigidbody), typeof(Animator))]
public sealed class CharacterBehaviour : BaseModel
{
    public InputMaster input;

    private CharacterInitialize _init;
    private Vector3 _tempPos;
    private Rigidbody _body;
    private Animator _animator;
    private Sequence _sequence;
    private SkinnedMeshRenderer _mesh;

    private void Awake()
    {
        input = new InputMaster();

        _init = new CharacterInitialize();
        _body = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        _sequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        _mesh.DOKill();
    }

    private void OnDestroy()
    {
        input.Disable();
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
            GetDamage();
            Services.Instance.CameraServices.CreateShake(ShakeType.Low);
            EventBus.RaiseEvent<ICollision>(h => h.PickBlock());
        }
        else if (target.TryGetComponent(out coin))
        {
            coin.Destroy();
            EventBus.RaiseEvent<ICollision>(h => h.PickCoin());
        }
    }

    private void GetDamage()
    {
        _sequence
            .Insert(0f, _mesh.material.DOFade(0f, 0f))
            .Append(_mesh.material.DOFade(1.0f, 1.0f));
    }

    public void Jump()
    {
        if (CheckGround())
        {
            _body.AddForce(Vector3.up * _init.jump, ForceMode.Impulse);
            _animator.SetTrigger(AnimationNameHelper.JUMP_ANIMATION);
        }
    }

    public void Move(float value)
    {
        if (CheckGround())
        {
            _tempPos = transform.position;

            if (Mathf.Approximately(_tempPos.z, _init.middlePos))
            {
                _body.MovePosition(Vector3.forward * value * _init.speed);
            }
            else if (Mathf.Approximately(_tempPos.z, _init.minPos) && value > 0 || Mathf.Approximately(_tempPos.z, _init.maxPos) && value < 0)
            {
                _body.MovePosition(Vector3.zero);
            }
        }
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _init.rayDis, LayerHelper.GroundLayer);
    }
}