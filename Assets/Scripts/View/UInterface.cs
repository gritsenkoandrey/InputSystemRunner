using UnityEngine;

public sealed class UInterface
{
    private UIShowTime _uiShowTime;
    private UIShowHealth _uiShowHealth;
    private UIShowCoin _uiShowCoin;
    private GameMenuBehaviour _gameMenuBehaviour;

    public UIShowTime UiShowTime
    {
        get
        {
            if (!_uiShowTime) _uiShowTime = Object.FindObjectOfType<UIShowTime>();
            return _uiShowTime;
        }
    }

    public UIShowHealth UiShowHealth
    {
        get
        {
            if (!_uiShowHealth) _uiShowHealth = Object.FindObjectOfType<UIShowHealth>();
            return _uiShowHealth;
        }
    }

    public UIShowCoin UiShowCoin
    {
        get
        {
            if (!_uiShowCoin) _uiShowCoin = Object.FindObjectOfType<UIShowCoin>();
            return _uiShowCoin;
        }
    }

    public GameMenuBehaviour GameMenuBehaviour
    {
        get
        {
            if (!_gameMenuBehaviour) _gameMenuBehaviour = Object.FindObjectOfType<GameMenuBehaviour>();
            return _gameMenuBehaviour;
        }
    }
}