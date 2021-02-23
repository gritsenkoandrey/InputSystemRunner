using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected bool isShowedUI;

    public abstract void Show();
    public abstract void Hide();
}