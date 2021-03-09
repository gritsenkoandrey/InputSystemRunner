using UnityEngine;
using UnityEngine.UI;

public sealed class UIHaveCoins : MonoBehaviour
{
    private Text _text;

    public int Text
    {
        set
        {
            _text.text = $"You have: {value} coins";
        }
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
}