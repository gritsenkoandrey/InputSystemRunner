using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIShowScore : MonoBehaviour
{
    private Text _text;
    private RectTransform _rectTransform;
    private readonly Sequence _sequence;

    public int Text
    {
        set { _text.text = $"{value}"; }
    }

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    public void ChangeScore()
    {
        _sequence.Insert(0f, _rectTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0f));
        _sequence.Append(_rectTransform.DOScale(Vector3.one, 1.0f));
    }
}