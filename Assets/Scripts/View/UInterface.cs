using UnityEngine;

public sealed class UInterface
{
    private UIShowScore _uiShowScore;
    private UIShowHealth _uiShowHealth;

    public UIShowScore UiShowScore
    {
        get
        {
            if (!_uiShowScore) _uiShowScore = Object.FindObjectOfType<UIShowScore>();
            return _uiShowScore;
        }
    }

    public UIShowHealth uiShowHealth
    {
        get
        {
            if (!_uiShowHealth) _uiShowHealth = Object.FindObjectOfType<UIShowHealth>();
            return _uiShowHealth;
        }
    }
}