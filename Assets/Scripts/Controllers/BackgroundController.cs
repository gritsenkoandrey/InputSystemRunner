public sealed class BackgroundController : BaseController, IInitialization, IExecute
{
    private readonly BackgroundInitialize _init;

    private readonly TimeRemaining _timeRemainingMove;
    private readonly float _timeToNextMove = 0.02f;

    public BackgroundController()
    {
        _init = new BackgroundInitialize();
        _init.data.Initialization();
        _timeRemainingMove = new TimeRemaining(Move, _timeToNextMove, true);
    }

    public void Initialization()
    {
        Switch(_init.data.backgroundBehaviour);
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        _init.data.backgroundBehaviour.ChangeBackgroundPosition(_init.destroyPos);
    }

    public override void On(params BaseModel[] models)
    {
        if (IsActive) return;
        if (models.Length > 0) _init.data.backgroundBehaviour = models[0] as BackgroundBehaviour;
        if (_init.data.backgroundBehaviour == null) return;
        base.On(_init.data.backgroundBehaviour);

        StartMove();
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();

        StopMove();
    }

    private void Move()
    {
        _init.data.backgroundBehaviour.Move(_init.speed);
    }

    private void StartMove()
    {
        _timeRemainingMove.AddTimeRemaining();
    }

    private void StopMove()
    {
        _timeRemainingMove.RemoveTimeRemaining();
    }
}