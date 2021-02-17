using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class CharacterAnimator : CharacterBase
{
    private readonly Sequence _sequence = null;
    private SkinnedMeshRenderer _mesh;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void Jump()
    {
        animator.SetTrigger(AnimationNameHelper.JUMP_ANIMATION);
    }

    public void GetDamage()
    {
        _sequence
            .Insert(0f, _mesh.material.DOFade(0f, 0f))
            .Append(_mesh.material.DOFade(1.0f, 1.0f));
    }
}