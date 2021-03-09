using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UInterface Interface;
    protected GameData data;

    protected virtual void Awake()
    {
        Interface = new UInterface();
        data = Data.Instance.GameData;
    }

    public abstract void Show();
    public abstract void Hide();
}