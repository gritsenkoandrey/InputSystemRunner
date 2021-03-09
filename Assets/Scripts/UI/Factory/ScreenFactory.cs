using UnityEngine;

public sealed class ScreenFactory
{
    private readonly Canvas _canvas;

    private GameMenuBehaviour _gameMenu;
    private MainMenuBehaviour _mainMenu;
    private GameOverMenuBehaviour _gameOverMenu;
    private PauseMenuBehaviour _pauseMenu;

    public ScreenFactory()
    {
        var resources = CustomResources.Load<Canvas>(AssetsPathGameObject.GameObjects[GameObjectType.Canvas]);
        _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);
    }

    public GameMenuBehaviour GetGameMenu()
    {
        if (_gameMenu == null)
        {
            var resources =
                CustomResources.Load<GameMenuBehaviour>(AssetsPathScreen.screens[ScreenType.GameMenu].screen);
            _gameMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity,
                _canvas.transform);
        }

        return _gameMenu;
    }

    public MainMenuBehaviour GetMainMenu()
    {
        if (_mainMenu == null)
        {
            var resources =
                CustomResources.Load<MainMenuBehaviour>(AssetsPathScreen.screens[ScreenType.MainMenu].screen);
            _mainMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity,
                _canvas.transform);
        }

        return _mainMenu;
    }

    public GameOverMenuBehaviour GetGameOverMenu()
    {
        if (_gameOverMenu == null)
        {
            var resources = 
                CustomResources.Load<GameOverMenuBehaviour>(AssetsPathScreen.screens[ScreenType.GameOverMenu].screen);
            _gameOverMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity,
                _canvas.transform);
        }

        return _gameOverMenu;
    }

    public PauseMenuBehaviour GetPauseMenu()
    {
        if (_pauseMenu == null)
        {
            var resources =
                CustomResources.Load<PauseMenuBehaviour>(AssetsPathScreen.screens[ScreenType.PauseMenu].screen);
            _pauseMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity,
                _canvas.transform);
        }

        return _pauseMenu;
    }
}