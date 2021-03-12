public sealed class LevelController : BaseController, IInitialization
{
    private int _coin = 0;
    private int _time = 0;
    private int _power;
    private int _health;
    private readonly int _maxPower;

    private readonly TimeRemaining _timeRemainingTimer;
    private readonly float _secondTimer = 1.0f;

    public LevelController()
    {
        _health = Data.Instance.Character.health;
        _maxPower = Data.Instance.Character.power;
        _timeRemainingTimer = new TimeRemaining(Timer, _secondTimer, true);
    }

    public void Initialization()
    {
        Subscribe();
    }

    private void Timer()
    {
        _power--;
        uInterface.UiShowPower.RefreshPower(_power);

        _time++;
        uInterface.UiShowTime.Text = _time;

        if (_power <= 0 || _health <= 0) Services.Instance.GameLevelService.EndGame();
    }

    private void StartTimer()
    {
        _power = _maxPower;
        uInterface.UiShowPower.RefreshPower(_power);
        uInterface.UiShowCoin.Text = _coin;
        uInterface.UiShowTime.Text = _time;
        _timeRemainingTimer.AddTimeRemaining();
    }

    private void StopTimer()
    {
        UnSubscribe();
        Data.Instance.GameData.SaveCoinsData(_coin);
        _timeRemainingTimer.RemoveTimeRemaining();
    }

    private void PickObstacle()
    {
        _power++;
        if (_power > _maxPower) _power = _maxPower;
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.PickObstacle));
        uInterface.UiShowPower.RefreshPower(_power);
    }

    private void PickCoin()
    {
        _coin++;
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.PickCoin));
        uInterface.UiShowCoin.ScaleText();
        uInterface.UiShowCoin.Text = _coin;
    }

    private void PickBlock()
    {
        _health--;
        Services.Instance.CameraServices.CreateShake(ShakeType.Low);
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.PickBlock));
        uInterface.UiShowHealth.RefreshHealth(_health);
    }

    private void HaveCoin(int coins)
    {
        uInterface.UIHaveCoins.Text = coins;
    }

    private void Subscribe()
    {
        Services.Instance.EventService.OnStartTimer += StartTimer;
        Services.Instance.EventService.OnStopTimer += StopTimer;
        Services.Instance.EventService.OnPickObstacle += PickObstacle;
        Services.Instance.EventService.OnPickCoin += PickCoin;
        Services.Instance.EventService.OnPickBlock += PickBlock;
        Services.Instance.EventService.OnHaveCoin += HaveCoin;
    }

    private void UnSubscribe()
    {
        Services.Instance.EventService.OnStartTimer -= StartTimer;
        Services.Instance.EventService.OnStopTimer -= StopTimer;
        Services.Instance.EventService.OnPickObstacle -= PickObstacle;
        Services.Instance.EventService.OnPickCoin -= PickCoin;
        Services.Instance.EventService.OnPickBlock -= PickBlock;
        Services.Instance.EventService.OnHaveCoin -= HaveCoin;
    }
}