using UnityEngine;

public sealed class BackgroundBehaviour : BaseModel
{
    public void Move(float speed)
    {
        transform.Translate(new Vector3(speed, 0.0f, 0.0f));
    }

    public void ChangeBackgroundPosition(float destroyPos)
    {
        if (transform.position.x < destroyPos)
        {
            transform.position = Vector3.zero;
        }
    }
}