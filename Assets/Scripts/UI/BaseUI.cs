using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public bool IsShowedUI { get; protected set; }

    public abstract void Show();
    public abstract void Hide();
}