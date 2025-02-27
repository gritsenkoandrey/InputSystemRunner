﻿using UnityEngine;

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
        Services.Instance.EventService.OnVisibleCharacter += VisibleCharacter;
        Services.Instance.EventService.OnCharacterDisable += DisableCharacter;
    }

    private void OnDisable()
    {
        IsVisible = false;
        Services.Instance.EventService.OnVisibleCharacter -= VisibleCharacter;
        Services.Instance.EventService.OnCharacterDisable -= DisableCharacter;
    }

    private void VisibleCharacter(bool value)
    {
        IsVisible = value;
    }

    private void DisableCharacter()
    {
        gameObject.SetActive(false);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _init.rayDis, LayerHelper.GroundLayer);
    }

    public void Jump()
    {
        if (CheckGround() && IsVisible)
        {
            _body.AddForce(Vector3.up * _init.jump, ForceMode.Impulse);
            _animator.SetTrigger(AnimationHelper.GetName(AnimationType.Jump));
            Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Jump));
        }
    }

    public void Move(float input)
    {
        if (CheckGround() && IsVisible)
        {
            var tempPos = transform.position;

            if (Mathf.Approximately(tempPos.z, _init.middlePos))
            {
                _body.MovePosition(Vector3.forward * input * _init.speed);
                Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Move));
            }
            else if (Mathf.Approximately(tempPos.z, _init.minPos) && input > 0 || Mathf.Approximately(tempPos.z, _init.maxPos) && input < 0)
            {
                _body.MovePosition(Vector3.zero);
                Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Move));
            }
        }
    }
}