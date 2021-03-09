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
        Services.Instance.EventService.StartLevel += StartGame;
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
        uInterface.UiShowCoin.Text = _coin;
        uInterface.UiShowTime.Text = _time;
        _timeRemainingTimer.AddTimeRemaining();
        Services.Instance.EventService.StartLevel -= StartGame;
        Services.Instance.EventService.StopLevel += EndGame;
        Services.Instance.EventService.OnPickObstacle += PickObstacle;
        Services.Instance.EventService.OnPickCoin += PickCoin;
        Services.Instance.EventService.OnPickBlock += PickBlock;
    }

    private void EndGame()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameOverMenu);
        Services.Instance.EventService.StopLevel -= EndGame;
        Services.Instance.EventService.OnPickObstacle -= PickObstacle;
        Services.Instance.EventService.OnPickCoin -= PickCoin;
        Services.Instance.EventService.OnPickBlock -= PickBlock;
        Data.Instance.GameData.SaveCoinsData(_coin);
        _timeRemainingTimer.RemoveTimeRemaining();
    }

    private void PickObstacle()
    {
        _power++;
        if (_power > _maxPower)
        {
            _power = _maxPower;
        }
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
}