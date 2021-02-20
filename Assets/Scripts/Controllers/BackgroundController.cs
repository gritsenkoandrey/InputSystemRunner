public sealed class BackgroundController : BaseController, IInitialization, IExecute
{
    private readonly BackgroundData _data;
    private readonly TimeRemaining _timeRemainingMove;
    private readonly float _timeToNextMove = 0.02f;

    public BackgroundController()
    {
        _data = Data.Instance.Background;
        _data.Initialization();

        _timeRemainingMove = new TimeRemaining(Move, _timeToNextMove, true);
    }

    public void Initialization()
    {
        Switch(_data.backgroundBehaviour);
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        _data.backgroundBehaviour.ChangeBackgroundPosition();
    }

    public override void On(params BaseModel[] models)
    {
        if (IsActive) return;
        if (models.Length > 0) _data.backgroundBehaviour = models[0] as BackgroundBehaviour;
        if (_data.backgroundBehaviour == null) return;
        base.On(_data.backgroundBehaviour);

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
        _data.backgroundBehaviour.Move();
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