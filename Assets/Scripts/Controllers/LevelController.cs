public sealed class LevelController : BaseController, IInitialization, IPickItem, IChangeHealth
{
    private int _countScore = 0;

    private readonly float _scale = 2.0f;
    private readonly float _duration = 1.0f;

    public void Initialization()
    {
        EventBus.Subscribe(this);

        uInterface.UiShowScore.Text = _countScore;
    }

    public void PickItem()
    {
        uInterface.UiShowScore.ChangeScore(_scale, _duration);
        _countScore++;
        uInterface.UiShowScore.Text = _countScore;
    }

    public void ChangeHealth(int health)
    {
        uInterface.uiShowHealth.RefreshHealth(health);
    }
}