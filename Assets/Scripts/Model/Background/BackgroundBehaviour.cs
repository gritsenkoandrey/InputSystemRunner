using UnityEngine;

public sealed class BackgroundBehaviour : BaseModel
{
    private BackgroundInitialize _init;

    private void Awake()
    {
        _init = new BackgroundInitialize();
    }

    private void OnEnable()
    {
        IsVisible = true;
        Services.Instance.EventService.OnBackgroundDisable += DestroyBackground;
    }

    private void OnDisable()
    {
        IsVisible = false;
        Services.Instance.EventService.OnBackgroundDisable -= DestroyBackground;
    }

    public void Move()
    {
        transform.Translate(new Vector3(_init.speed, 0.0f, 0.0f));

        if (transform.position.x < _init.destroyPos)
        {
            transform.position = Vector3.zero;
        }
    }

    private void DestroyBackground()
    {
        gameObject.SetActive(false);
    }
}