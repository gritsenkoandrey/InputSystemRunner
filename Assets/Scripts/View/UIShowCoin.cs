using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIShowCoin : MonoBehaviour
{
    private Text _text;
    private RectTransform _rectTransform;
    private Sequence _sequence;
    private readonly float _scale = 2.0f;
    private readonly float _duration = 1.0f;

    public int Text { set { _text.text = $"{value}"; } }

    private void OnEnable()
    {
        _text = GetComponentInChildren<Text>();
        _rectTransform = _text.GetComponent<RectTransform>();
        _sequence = DOTween.Sequence();
    }

    private void OnDisable()
    {
        _rectTransform.DOKill();
    }

    public void SetActive(bool value)
    { 
        gameObject.SetActive(value);
    }

    public void ScaleText()
    {
        _sequence
            .Insert(0f, _rectTransform.DOScale(Vector3.one * _scale, 0f))
            .Append(_rectTransform.DOScale(Vector3.one, _duration));
    }
}