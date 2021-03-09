using UnityEngine;

public sealed class UIGameOver : MonoBehaviour
{
    private void Start()
    {
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.GameOver));
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}