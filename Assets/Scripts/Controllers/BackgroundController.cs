using UnityEngine;

public sealed class BackgroundController : BaseController, IInitialization, IExecute
{
    private readonly BackgroundData _backgroundData;
    private readonly float _speed;
    private readonly float _destroyPos;

    private readonly TimeRemaining _timeRemainingMove;
    private readonly float _timeToNextMove = 0.02f;

    public BackgroundController()
    {
        _backgroundData = Data.Instance.Background;
        _speed = _backgroundData.speed;
        _destroyPos = _backgroundData.destroyPos;

        _backgroundData.InitializationBackground();

        _timeRemainingMove = new TimeRemaining(Move, _timeToNextMove, true);
    }

    public void Initialization()
    {
        Switch(_backgroundData.backgroundModel);
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        _backgroundData.backgroundModel.ChangeBackgroundPosition(_destroyPos);
    }

    public override void On(params BaseModel[] models)
    {
        if (IsActive) return;
        if (models.Length > 0) _backgroundData.backgroundModel = models[0] as BackgroundModel;
        if (_backgroundData.backgroundModel == null) return;
        base.On(_backgroundData.backgroundModel);

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
        _backgroundData.backgroundModel.Move(_speed);
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