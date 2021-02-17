using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIShowScore : MonoBehaviour
{
    private Text _text;
    private RectTransform _rectTransform;
    private readonly Sequence _sequence = null;

    public int Text
    {
        set { _text.text = $"{value}"; }
    }

    private void Start()
    {
        _text = GetComponent<Text>();
        _rectTransform = _text.GetComponent<RectTransform>();
    }

    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    public void ChangeScore(float scale, float duration)
    {
        _sequence
            .Insert(0f, _rectTransform.DOScale(Vector3.one * scale, 0f))
            .Append(_rectTransform.DOScale(Vector3.one, duration));
    }
}