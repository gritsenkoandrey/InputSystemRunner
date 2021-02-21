public sealed class LevelController : BaseController, IInitialization, ICollision
{
    private int _countCoin = 0;

    private int _timer;
    private readonly int _maxTimer = 10;
    private int _health;

    private readonly TimeRemaining _timeRemainingTimer;
    private readonly float _secondTimer = 1.0f;

    public LevelController()
    {
        EventBus.Subscribe(this);
        _health = Data.Instance.Character.health;
        _timeRemainingTimer = new TimeRemaining(Timer, _secondTimer, true);
    }

    public void Initialization()
    {
        StartGame();
    }

    private void Timer()
    {
        _timer--;
        uInterface.UiShowTime.Text = _timer;

        if (_timer <= 5) uInterface.UiShowTime.ScaleText();
        if (_timer <= 0 || _health <= 0) GameOver();
    }

    private void StartGame()
    {
        _timer = _maxTimer;
        uInterface.UiShowTime.Text = _timer;
        uInterface.UiShowCoin.Text = _countCoin;
        _timeRemainingTimer.AddTimeRemaining();
    }

    private void GameOver()
    {
        uInterface.UiShowTime.SetActive(false);
        uInterface.UiShowCoin.SetActive(false);
        uInterface.UiShowHealth.SetActive(false);
        uInterface.GameMenuBehaviour.GameOver();
        _timeRemainingTimer.RemoveTimeRemaining();
        UserData.SaveData(_countCoin);
        EventBus.Unsubscribe(this);
    }

    public void PickObstacle()
    {
        _timer++;
        if (_timer > _maxTimer) _timer = _maxTimer;
        uInterface.UiShowTime.ColorText();
        uInterface.UiShowTime.Text = _timer;
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