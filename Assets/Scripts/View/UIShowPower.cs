using UnityEngine;

public class UIShowPower : MonoBehaviour
{
    private Transform[] _power;

    private void OnEnable()
    {
        _power = new Transform[Data.Instance.Character.power];

        for (var i = 0; i < _power.Length; i++)
        {
            _power[i] = transform.GetChild(i);
        }
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void RefreshPower(int power)
    {
        for (var i = 0; i < _power.Length; i++)
        {
            if (i < power) _power[i].gameObject.SetActive(true);
            else _power[i].gameObject.SetActive(false);
        }
    }
}