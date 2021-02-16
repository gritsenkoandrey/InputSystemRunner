using UnityEngine;

public sealed class UInterface
{
    private UIShowScore _uiShowScore;

    public UIShowScore UiShowScore
    {
        get
        {
            if (!_uiShowScore) _uiShowScore = Object.FindObjectOfType<UIShowScore>();
            return _uiShowScore;
        }
    }
}