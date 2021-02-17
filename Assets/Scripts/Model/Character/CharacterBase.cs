using UnityEngine;

public abstract class CharacterBase : BaseModel
{
    private CharacterData _data;

    protected CharacterMove characterMove;
    protected CharacterHealth characterHealth;
    protected CharacterAnimator characterAnimator;

    protected int health;
    protected float maxPos;
    protected float minPos;
    protected float middlePos;
    protected float speed;
    protected float jump;
    protected float rayDis;
    protected Vector3 tempPos;

    protected Rigidbody body;
    protected Animator animator;

    protected virtual void Awake()
    {
        InitializeData();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void InitializeData()
    {
        _data = Data.Instance.Character;
        health = _data.health;
        maxPos = _data.maxPos;
        minPos = _data.minPos;
        middlePos = _data.middlePos;
        speed = _data.speed;
        jump = _data.jump;
        rayDis = _data.rayDis;
    }
}