using UnityEngine;

public class UIShowPower : UInterfaceBase
{
    private Transform[] _power;

    private void Awake()
    {
        _power = new Transform[Data.Instance.Character.power];

        for (var i = 0; i < _power.Length; i++)
        {
            _power[i] = transform.GetChild(i);
        }
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