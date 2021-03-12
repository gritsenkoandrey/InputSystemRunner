public sealed class BackgroundController : BaseController, IInitialization, IFixExecute
{
    private readonly BackgroundData _data;

    public BackgroundController()
    {
        _data = Data.Instance.Background;
    }

    public void Initialization()
    {
        Services.Instance.EventService.OnBackgroundEnable += SpawnBackground;
    }

    public void FixedExecute()
    {
        if (!IsActive)
        {
            if (_data.backgroundBehaviour && _data.backgroundBehaviour.IsVisible)
            {
                On(_data.backgroundBehaviour);
            }
            return;
        }
        else
        {
            if (!_data.backgroundBehaviour.IsVisible)
            {
                Off();
            }

            MovementBackground();
        }
    }

    private void SpawnBackground()
    {
        _data.Initialization();
        Services.Instance.EventService.OnBackgroundEnable -= SpawnBackground;
    }

    private void MovementBackground()
    {
        _data.backgroundBehaviour.Move();
    }

    public override void On(params BaseModel[] models)
    {
        if (IsActive) return;
        if (models.Length > 0) _data.backgroundBehaviour = models[0] as BackgroundBehaviour;
        if (_data.backgroundBehaviour == null) return;
        base.On(_data.backgroundBehaviour);
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();
    }
}