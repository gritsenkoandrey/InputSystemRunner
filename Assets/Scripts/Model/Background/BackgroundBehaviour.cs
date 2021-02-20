using UnityEngine;

public sealed class BackgroundBehaviour : BaseModel
{
    private BackgroundInitialize _init;

    private void Awake()
    {
        _init = new BackgroundInitialize();
    }

    public void Move()
    {
        transform.Translate(new Vector3(_init.speed, 0.0f, 0.0f));
    }

    public void ChangeBackgroundPosition()
    {
        if (transform.position.x < _init.destroyPos)
        {
            transform.position = Vector3.zero;
        }
    }
}