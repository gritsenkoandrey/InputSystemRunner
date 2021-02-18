using UnityEngine;

public sealed class LevelController : BaseController, IInitialization, ICollision
{
    private int _countCoin = 0;

    private int _timer = 10;
    private int _health;

    private readonly TimeRemaining _timeRemainingTimer;
    private readonly float _time = 1.0f;

    public LevelController()
    {
        EventBus.Subscribe(this);
        _health = Data.Instance.Character.health;
        _timeRemainingTimer = new TimeRemaining(Timer, _time, true);
    }

    public void Initialization()
    {
        uInterface.UiShowTime.Text = _timer;
        uInterface.UiShowCoin.Text = _countCoin;

        _timeRemainingTimer.AddTimeRemaining();
    }

    private void Timer()
    {
        _timer--;
        uInterface.UiShowTime.Text = _timer;

        if (_timer < 6)
        {
            uInterface.UiShowTime.ScaleText();
        }

        if (_timer <= 0 || _health <= 0)
        {
            uInterface.UiShowTime.SetActive(false);
            uInterface.UiShowCoin.SetActive(false);
            uInterface.UiShowHealth.SetActive(false);
            _timeRemainingTimer.RemoveTimeRemaining();
            UserData.SaveData(_countCoin);
            EventBus.Unsubscribe(this);
            uInterface.GameMenu.GameOver();
        }
    }

    public void PickObstacle()
    {
        _timer++;
        uInterface.UiShowTime.ColorText(Color.green);
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