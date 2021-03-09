using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UInterface uInterface;
    protected GameData data;

    protected virtual void Awake()
    {
        uInterface = new UInterface();
        data = Data.Instance.GameData;
    }

    public abstract void Show();
    public abstract void Hide();
}