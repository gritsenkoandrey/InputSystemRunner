using UnityEngine;

public sealed class UIShowHealth : UInterfaceBase
{
    private Transform[] _health;

    private void Awake()
    {
        _health = new Transform[Data.Instance.Character.health];

        for (var i = 0; i < _health.Length; i++)
        {
            _health[i] = transform.GetChild(i);
        }
    }

    public void RefreshHealth(int health)
    {
        for (var i = 0; i < _health.Length; i++)
        {
            if (i < health) _health[i].gameObject.SetActive(true);
            else _health[i].gameObject.SetActive(false);
        }
    }
}