public sealed class BackgroundController : BaseController, IInitialization, IFixExecute
{
    private readonly BackgroundData _data;

    public BackgroundController()
    {
        _data = Data.Instance.Background;
        _data.Initialization();
    }

    public void Initialization()
    {
        Switch(_data.backgroundBehaviour);
    }

    public void FixedExecute()
    {
        if (!IsActive) return;

        MovementBackground();
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

    private void MovementBackground()
    {
        _data.backgroundBehaviour.Move();
        _data.backgroundBehaviour.Loop();
    }
}