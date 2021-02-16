using UnityEngine;


[RequireComponent(typeof(Rigidbody),
    typeof(BoxCollider),
    typeof(Animator))]
public sealed class CharacterModel : BaseModel
{
    private CharacterData _characterData;

    private float _maxPos;
    private float _minPos;
    private float _middlePos;
    private float _speed;
    private float _jump;
    private float _rayDis;

    private Vector3 _tempPos;
    private Rigidbody _body;
    private Animator _animator;

    private void Awake()
    {
        InitializationCharacter();

        _body = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.TryGetComponent(out obstacle))
        {
            EventBus.RaiseEvent<IPickItem>(h => h.PickItem());

            obstacle.DestroyObstacle();
        }
    }

    public void Jump()
    {
        if (CheckGround())
        {
            _body.AddForce(Vector3.up * _jump, ForceMode.Impulse);
            _animator.SetTrigger(AnimationNameHelper.JUMP_ANIMATION);
        }
    }

    public void Move(float input)
    {
        if (CheckGround())
        {
            _tempPos = transform.position;

            if (Mathf.Approximately(_tempPos.z, _middlePos))
            {
                _body.MovePosition(new Vector3(0f, 0f, input * _speed));
            }
            else if (Mathf.Approximately(_tempPos.z, _minPos) && input > 0 || Mathf.Approximately(_tempPos.z, _maxPos) && input < 0)
            {
                _body.MovePosition(Vector3.zero);
            }
        }
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _rayDis, LayerHelper.GroundLayer);
    }

    private void InitializationCharacter()
    {
        _characterData = Data.Instance.Character;
        _maxPos = _characterData.maxPos;
        _minPos = _characterData.minPos;
        _middlePos = _characterData.middlePos;
        _speed = _characterData.speed;
        _jump = _characterData.jump;
        _rayDis = _characterData.rayDis;
    }
}