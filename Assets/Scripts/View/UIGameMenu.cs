using UnityEngine;

public sealed class UIGameMenu : MonoBehaviour
{
    private void Start()
    {
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.GameTheme));
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}