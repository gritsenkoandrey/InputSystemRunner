using UnityEngine;

public abstract class UInterfaceBase : MonoBehaviour
{
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}