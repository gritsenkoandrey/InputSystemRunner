using UnityEngine;

public abstract class UInterfaceBase : MonoBehaviour
{
    public virtual void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}