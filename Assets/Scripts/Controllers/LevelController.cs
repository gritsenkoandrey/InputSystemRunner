public sealed class LevelController : BaseController, IInitialization, ICollision, IStartGame
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
    }

    private void Timer()
    {
        _power--;
        _time++;
        uInterface.UiShowPower.RefreshPower(_power);
        uInterface.UiShowTime.Text = _time;
        if (_power <= 0 || _health <= 0) GameOver();
    }

    public void StartGame()
    {
        _power = _maxPower;
        uInterface.UiShowPower.RefreshPower(_power);
        uInterface.UiShowCoin.Text = _countCoin;
        uInterface.UiShowTime.Text = _time;
        _timeRemainingTimer.AddTimeRemaining();
    }

    private void GameOver()
    {
        uInterface.UiShowPower.SetActive(false);
        uInterface.UiShowCoin.SetActive(false);
        uInterface.UiShowHealth.SetActive(false);
        uInterface.UiShowTime.SetActive(false);
        uInterface.GameMenuBehaviour.ShowGameOver();
        _timeRemainingTimer.RemoveTimeRemaining();
        UserData.SaveData(_countCoin);
        EventBus.Unsubscribe(this);
    }

    public void PickObstacle()
    {
        _power++;
        if (_power > _maxPower) _power = _maxPower;
        uInterface.UiShowPower.RefreshPower(_power);
    }

    public void PickCoin()
    {
        _countCoin++;
        uInterface.UiShowCoin.ScaleText();
        uInterface.UiShowCoin.Text = _countCoin;
    }

    public void PickBlock()
    {
        _health--;
        uInterface.UiShowHealth.RefreshHealth(_health);
    }
}