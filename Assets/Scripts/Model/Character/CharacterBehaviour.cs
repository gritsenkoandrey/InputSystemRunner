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
        IsVisible = true;
        Services.Instance.EventService.OffCharacter += DestroyCharacter;
    }

    private void OnDisable()
    {
        IsVisible = false;
        Services.Instance.EventService.OffCharacter -= DestroyCharacter;
    }

    private void DestroyCharacter()
    {
        gameObject.SetActive(false);
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
            _animator.SetTrigger(AnimationName.JUMP_ANIMATION);
            Services.Instance.AudioService.PlaySound(AudioName.JUM_ELVIS);
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