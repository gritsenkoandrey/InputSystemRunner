using UnityEngine;

public sealed class UIShowHealth : MonoBehaviour
{
    private Transform[] _health;

    private void OnEnable()
    {
        _health = new Transform[Data.Instance.Character.health];

        for (var i = 0; i < _health.Length; i++)
        {
            _health[i] = transform.GetChild(i);
        }
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
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