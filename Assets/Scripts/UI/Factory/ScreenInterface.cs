public sealed class ScreenInterface
{
    private BaseMenu _currentWindow;
    private readonly ScreenFactory _screenFactory;
    private static ScreenInterface _instance;

    private ScreenInterface()
    {
        _screenFactory = new ScreenFactory();
    }

    public static ScreenInterface GetScreenInterface()
    {
        if (_instance != null) return _instance;
        else return _instance = new ScreenInterface();
    }

    public void Execute(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.GameMenu:
                _currentWindow = _screenFactory.GetGameMenu();
                _currentWindow.Show();
                break;
            case ScreenType.MainMenu:
                _currentWindow = _screenFactory.GetMainMenu();
                _currentWindow.Show();
                break;
        }
    }

    public static void CleanScreenInterface()
    {
        _instance = null;
    }
}