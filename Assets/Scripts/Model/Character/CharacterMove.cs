using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class CharacterMove : CharacterBase
{
    protected override void Awake()
    {
        base.Awake();
        body = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (CheckGround())
        {
            body.AddForce(Vector3.up * jump, ForceMode.Impulse);
            characterAnimator.Jump();
            Debug.Log(jump);
        }
    }

    public void Move(float input)
    {
        if (CheckGround())
        {
            tempPos = transform.position;

            if (Mathf.Approximately(tempPos.z, middlePos))
            {
                body.MovePosition(Vector3.forward * input * speed);
            }
            else if (Mathf.Approximately(tempPos.z, minPos) && input > 0 || Mathf.Approximately(tempPos.z, maxPos) && input < 0)
            {
                body.MovePosition(Vector3.zero);
            }
        }
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDis, LayerHelper.GroundLayer);
    }
}