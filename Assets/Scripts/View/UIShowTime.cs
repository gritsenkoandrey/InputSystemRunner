using UnityEngine.UI;

public sealed class UIShowTime : UIBase
{
    private Text _text;

    public int Text { set { _text.text = $"{value}"; } }

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }
}