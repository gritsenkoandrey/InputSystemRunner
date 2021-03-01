public sealed class LevelController : BaseController, IInitialization, ICollisionItem
{
    private int _countCoin = 0;
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
        EventBus.Subscribe(this);
        Services.Instance.EventService.StartLevel += StartGame;
        Services.Instance.EventService.StopLevel += EndGame;
    }

    private void Timer()
    {
        _power--;
        uInterface.UiShowPower.RefreshPower(_power);

        _time++;
        uInterface.UiShowTime.Text = _time;

        if (_power <= 0 || _health <= 0)
        {
            Services.Instance.GameLevelService.GameOver();
        }
    }

    private void StartGame()
    {
        _power = _maxPower;
        uInterface.UiShowPower.RefreshPower(_power);
        uInterface.UiShowCoin.Text = _countCoin;
        uInterface.UiShowTime.Text = _time;
        _timeRemainingTimer.AddTimeRemaining();
        Services.Instance.EventService.StartLevel -= StartGame;
    }

    private void EndGame()
    {
        uInterface.GameMenuBehaviour.ShowGameOver();
        _timeRemainingTimer.RemoveTimeRemaining();
        UserData.SaveData(_countCoin);
        EventBus.Unsubscribe(this);
        Services.Instance.EventService.StopLevel -= EndGame;
    }

    public void PickObstacle()
    {
        _power++;
        if (_power > _maxPower)
        {
            _power = _maxPower;
        }
        Services.Instance.AudioService.PlaySound(AudioName.PICK_OBSTACLE);
        uInterface.UiShowPower.RefreshPower(_power);
    }

    public void PickCoin()
    {
        _countCoin++;
        Services.Instance.AudioService.PlaySound(AudioName.PICK_COIN);
        uInterface.UiShowCoin.ScaleText();
        uInterface.UiShowCoin.Text = _countCoin;
    }

    public void PickBlock()
    {
        _health--;
        Services.Instance.CameraServices.CreateShake(ShakeType.Low);
        Services.Instance.AudioService.PlaySound(AudioName.DAMAGE_ELVIS);
        uInterface.UiShowHealth.RefreshHealth(_health);
    }
}