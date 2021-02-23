using UnityEngine;

public abstract class BaseMenu : MonoBehaviour
{
    protected bool isShowedMenu;

    public abstract void Show();
    public abstract void Hide();
}