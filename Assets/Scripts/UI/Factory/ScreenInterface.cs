﻿public sealed class ScreenInterface
{
    private BaseUI _currentWindow;
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
        _currentWindow?.Hide();

        switch (screenType)
        {
            case ScreenType.GameMenu:
                _currentWindow = _screenFactory.GetGameMenu();
                break;
            case ScreenType.MainMenu:
                _currentWindow = _screenFactory.GetMainMenu();
                break;
        }

        _currentWindow?.Show();
    }

    public static void CleanScreenInterface()
    {
        _instance = null;
    }
}