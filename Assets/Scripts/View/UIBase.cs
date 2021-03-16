using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public virtual void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}