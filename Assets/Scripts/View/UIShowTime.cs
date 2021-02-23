using UnityEngine;
using UnityEngine.UI;

public sealed class UIShowTime : MonoBehaviour
{
    private Text _text;

    public int Text { set { _text.text = $"{value}"; } }

    private void OnEnable()
    {
        _text = GetComponentInChildren<Text>();
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}