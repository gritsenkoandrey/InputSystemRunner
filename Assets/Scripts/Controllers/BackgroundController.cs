public sealed class BackgroundController : BaseController, IInitialization, IFixExecute
{
    private readonly BackgroundData _data;

    public BackgroundController()
    {
        _data = Data.Instance.Background;
    }

    public void Initialization()
    {
        _data.Initialization();
    }

    public void FixedExecute()
    {
        if (!IsActive)
        {
            if (_data.backgroundBehaviour && _data.backgroundBehaviour.IsActive)
            {
                On(_data.backgroundBehaviour);
            }
            return;
        }
        else
        {
            if (!_data.backgroundBehaviour.IsActive)
            {
                Off();
            }

            MovementBackground();
        }
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