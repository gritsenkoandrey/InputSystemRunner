using UnityEngine;

public sealed class UInterface
{
    private UIShowTime _uiShowTime;
    private UIShowHealth _uiShowHealth;
    private UIShowPower _uiShowPower;
    private UIShowCoin _uiShowCoin;
    private UIHaveCoins _uIHaveCoins;

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

    public UIShowPower UiShowPower
    {
        get
        {
            if (!_uiShowPower) _uiShowPower = Object.FindObjectOfType<UIShowPower>();
            return _uiShowPower;
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

    public UIHaveCoins UIHaveCoins
    {
        get
        {
            if (!_uIHaveCoins) _uIHaveCoins = Object.FindObjectOfType<UIHaveCoins>();
            return _uIHaveCoins;
        }
    }
}